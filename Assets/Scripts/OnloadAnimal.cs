using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnloadAnimal : MonoBehaviour
{
    [System.Serializable]
    public struct AnimalModelMap
    {
        public string animal;
        public GameObject modelPrefab;
        public Animal.Species species;
        public Animal.Colour colour;
    }

    public AnimalDBManager animalDB;
    public GameObject animalObject;
    public AnimalModelMap[] animalModels;
    public PrefabLoader prefabLoader;
    public GameObject nametagTag;

    void Awake()
    {
        bool doNewPet = PlayerPrefs.GetInt("CreateNewPet", 0) == 1;
        // exit if a new pet is not being made
        if (doNewPet)
        {
            setNewPet();
        }
        else
        {
            loadSavedPet();
        }

    }

    void Start()
    {
    }

    void Update()
    {
    }

    private void setNewPet()
    {
        // Load new pet depending on Species
        string newPet = PlayerPrefs.GetString("NewPetType");
        foreach (AnimalModelMap modelData in animalModels)
        {
            if (newPet == modelData.animal)
            {
                GameObject newAnimalObj = prefabLoader.LoadAnimalPrefabAsChild(modelData.species, this.animalObject);
            }
        }
    }

    private void loadSavedPet()
    {
        int id = PlayerPrefs.GetInt("SelectedPetID");
        List<Animal> list = animalDB.getAnimals();

        foreach (Animal animal in list)
        {
            // If matches, apply the pet to player
            if (animal.id == id)
            {
                // Create the animal model
                prefabLoader.LoadAnimalPrefabAsChild(animal.species, this.animalObject);
                // Apply the animal's stats to the animal object
                applyToPlayer(this.animalObject, animal);
                // Return as the loading of the selected animal is complete
                return;
            }
        }
    }

    // Apply a selected animal's stats and data to the player game object
    private void applyToPlayer(GameObject player, Animal selected)
    {
        // Load animal data
        AnimalStore store = new AnimalStore(selected);
        // Apply data to animal
        store.applyToAnimal(player.GetComponent<Animal>());
        player.tag = "Player";
        // Show pet name tag
        nametagTag.GetComponent<TextMeshProUGUI>().text = selected.animalName;
    }

    private AnimalModelMap getDataForAnimal(string animal)
    {
        foreach (AnimalModelMap data in this.animalModels)
        {
            if (data.animal == animal)
            {
                return data;
            }
        }
        return new AnimalModelMap();
    }
}
