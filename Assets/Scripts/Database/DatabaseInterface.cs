using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DatabaseInterface : MonoBehaviour
{
    public Animal curAnimal;

    private Database database;
    private Dictionary<string, Animal> animals;

    void Start()
    {
        this.database = ScriptableObject.CreateInstance<Database>();
        database.Init();

        loadAnimals();

        List<Animal> list = new List<Animal>(this.animals.Values);
        Animal selected = list[0]; // default to first animal for now
        applyToPlayer(selected);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // testing
        {
            saveCurAnimal();
        }
    }

    public void Save()
    {
        // save current animal to loaded list
        saveCurAnimal();

        // save to database
        database.Clear();
        foreach (Animal animal in animals.Values)
        {
            writeAnimal(animal);
        }
    }

    private void applyToPlayer(Animal selected)
    {
        this.curAnimal = new AnimalStore(selected).loadAnimal();
    }

    private void saveCurAnimal()
    {
        animals[this.curAnimal.id] = this.curAnimal;
    }

    private Animal loadAnimal(string id)
    {
        if (this.animals.ContainsKey(id))
        {
            return this.animals[id];
        }
        else
        {
            Debug.Log($"Animal ID ${id} does not exist.");
            return null;
        }
    }

    private void loadAnimals()
    {
        this.animals = new Dictionary<string, Animal>();

        string[] lines = database.ReadLines();
        foreach (string line in lines)
        {
            AnimalStore store = new AnimalStore();
            store.loadCSVLine(line);

            Animal animal = store.loadAnimal();
            this.animals[animal.id] = animal;
            Debug.Log($"Loaded animal {animal.id}");
        }
    }

    private void writeAnimal(Animal animal)
    {
        AnimalStore store = new AnimalStore(animal);
        database.Write(store.createCSVLine());
    }

}
