using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnedPets : MonoBehaviour
{

    public AnimalDBManager animalDB;
    public List<Animal> animals;
    public GameObject parent;
    public PrefabLoader prefabLoader;

    public int startX = 0;
    public int startY = 0;
    public int maxX = 1000;
    public int maxY = 1000;
    public int separation = 100;
    public int scale = 1;

    private int curX;
    private int curY;

    void Awake()
    {
        this.curX = startX;
        this.curY = startY;
    }

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
            animalObj.transform.localScale = new Vector3(this.scale, this.scale, 1);
            animalObj.transform.parent = parent.transform;

            // Set animal location
            animalObj.transform.localPosition = new Vector3(curX, curY, 0);

            // Increase coordinates
            curX += separation;
            if (curX > maxX)
            {
                curX = startX;
                curY += separation;
            }

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
