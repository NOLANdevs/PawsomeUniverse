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
            setSavedPet();
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
        GameObject animalPrefab = animalData.modelPrefab;
        GameObject newAnimalObject = Instantiate(animalPrefab); // Instantiate the prefab model
        // Set animal's variables
        newAnimalObject.transform.parent = animalObject.transform;
        newAnimalObject.transform.localPosition = animalPrefab.transform.localPosition;
        newAnimalObject.transform.localScale = animalPrefab.transform.localScale;
        newAnimalObject.tag = "Animated";
    }

    private void setSavedPet()
    {
        List<Animal> list = new List<Animal>(animalDB.animals.Values);
        if (list.Count > 0)
        {
            Animal selected = list[0]; // default to first animal for now // TODO
            applyToPlayer(selected);
        }
    }

    private void applyToPlayer(Animal selected)
    {
        AnimalStore store = new AnimalStore(selected);
        store.applyToAnimal(this.animalObject.GetComponent<Animal>());
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
