using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnedPets : MonoBehaviour
{

    public AnimalDBManager animalDB;
    public List<Animal> animals;
    public GameObject parent;
    public PrefabLoader prefabLoader;

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
            // Spawn animal model as child of animal object
            GameObject animalModel = prefabLoader.LoadAnimalAsChild(animal.species, animalObj);
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
}
