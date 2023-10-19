using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnedPets : MonoBehaviour
{

    [System.Serializable]
    public struct AnimalModels
    {
        public Animal.Species species;
        public GameObject prefab;
    }

    public AnimalDBManager animalDB;
    public List<Animal> animals;
    public GameObject parent;
    public AnimalModels[] animalModels;

    void Start()
    {
        animals = animalDB.getAnimals();

        ShowOwnedPets();
    }

    public void ShowOwnedPets()
    {
        foreach (var animal in animals)
        {
            // Instantiate animal
            GameObject animalObj = instantiateAnimal(animal);
            animalObj.transform.parent = parent.transform;
            // Apply prefab model to the animal
            GameObject animalPrefab = findAnimalData(animal.species).prefab;
            GameObject animalModel = ObjectLoader.LoadPrefabAsChild(animalPrefab, animalObj);
            animalModel.tag = "Animated";
        }
    }

    private GameObject instantiateAnimal(Animal animal)
    {
        AnimalStore store = new AnimalStore(animal);
        GameObject animalObj = new GameObject("Animal" + animal.id);
        Animal animalComponent = animalObj.AddComponent<Animal>();
        store.applyToAnimal(animalComponent);
        return animalObj;
    }

    private AnimalModels findAnimalData(Animal.Species species)
    {
        foreach (AnimalModels data in this.animalModels)
        {
            if (data.species == species)
            {
                return data;
            }
        }
        return new AnimalModels();
    }
}
