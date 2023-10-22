using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OwnedPets : MonoBehaviour
{

    public AnimalDBManager animalDB;
    public List<Animal> animals;
    public GameObject parent;
    public PrefabLoader prefabLoader;
    public GameObject textLabelPrefab;

    public int startX = 0;
    public int startY = 0;
    public int maxX = 1000;
    public int maxY = 1000;
    public int separation = 100;
    public float scale = 1;

    private int curX;
    private int curY;

    void Awake()
    {
        this.curX = startX;
        this.curY = startY;
        this.separation = (int)(this.separation * this.scale);
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
            // Container
            GameObject container = new GameObject("Animal" + animal.id + "Container");
            container.transform.SetParent(parent.transform);
            container.transform.localPosition = new Vector3(curX, curY, 0);
            GameObject textLabelObj = prefabLoader.LoadPrefabAsChild(textLabelPrefab, container);

            // Instantiate animal
            GameObject animalObj = instantiateAnimal(animal);
            animalObj.transform.localScale = new Vector3(this.scale, this.scale, 1);
            animalObj.transform.SetParent(container.transform);
            animalObj.transform.localPosition = Vector3.zero;

            // Instantiate label
            var textComponent = textLabelObj.GetComponent<TextMeshProUGUI>();
            if (animal.animalName.Length > 0)
            {
                textComponent.text = animal.animalName;
            }

            // Set objects' locations

            // Increase coordinates
            curX += separation;
            if (curX > maxX)
            {
                curX = startX;
                curY -= separation;
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
