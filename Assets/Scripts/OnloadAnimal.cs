using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // Delete default animal data
        Animal oldScript = animalObject.GetComponent<Animal>();
        if (oldScript != null)
        {
            Destroy(oldScript);
        }

        // Load new pet
        string newPet = PlayerPrefs.GetString("NewPetType");
        Animal animal = animalObject.AddComponent<Animal>(); // Create animal component
        // Set animal's data
        AnimalModelMap animalData = getDataForAnimal(newPet);
        animal.species = animalData.species;
        animal.colour = animalData.colour;
        // Load prefab as child
        GameObject animalModel = prefabLoader.LoadPrefabAsChild(animalData.modelPrefab, animalObject);
        animalModel.tag = "Animated";
    }

    private void loadSavedPet()
    {
        int id = PlayerPrefs.GetInt("SelectedPetID");
        List<Animal> list = animalDB.getAnimals();

        foreach (Animal animal in list)
        {
            Debug.Log(animal.id + "=" + id);
            // If matches, apply the pet to player
            if (animal.id == id)
            {
                applyToPlayer(animal);
                return;
            }
        }
    }

    private void applyToPlayer(Animal selected)
    {
        AnimalStore store = new AnimalStore(selected);
        store.applyToAnimal(this.animalObject.GetComponent<Animal>());
        this.animalObject.tag = "Player";
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
