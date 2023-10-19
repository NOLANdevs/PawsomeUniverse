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
            GameObject animalObj = instantiateAnimal(animal);
            animalObj.transform.parent = parent.transform;
            instantiateAnimalModel(animal, animalObj);
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

    private void instantiateAnimalModel(Animal animal, GameObject animalObject)
    {
        AnimalModels data = findAnimalData(animal.species);
        GameObject animalPrefab = data.prefab;
        GameObject animalModel = Instantiate(animalPrefab); // Instantiate the prefab model
        // Set animal's variables
        animalModel.transform.parent = animalObject.transform;
        animalModel.transform.localPosition = animalPrefab.transform.localPosition;
        animalModel.transform.localScale = animalPrefab.transform.localScale;
        animalModel.tag = "Animated";
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
