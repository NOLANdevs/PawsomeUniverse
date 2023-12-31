using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AnimalDBManager : IDatabaseManager
{
    public static Database animalsDB;
    public Dictionary<int, Animal> animals;

    void Awake()
    {
        animalsDB = ScriptableObject.CreateInstance<Database>();
        animalsDB.Init("animals.db");
        loadAnimals();
    }

    void Start()
    {
    }

    public override void Save()
    {
        // save current animal to loaded list
        storeCurAnimal();

        // save to DB
        saveAnimals();
    }

    public List<Animal> getAnimals()
    {
        return new List<Animal>(this.animals.Values);
    }

    private void storeCurAnimal()
    {
        Animal curAnimal = GameLogic.activeAnimal;
        this.animals[curAnimal.id] = curAnimal;
    }

    private void saveAnimals()
    {
        foreach (Animal animal in animals.Values)
        {
            writeAnimal(animal);
        }
        animalsDB.Deduplicate(0);

        Debug.Log($"Saved {animals.Count} animals to database.");
    }

    private Animal loadAnimal(int id)
    {
        if (this.animals.ContainsKey(id))
        {
            return this.animals[id];
        }
        else
        {
            Debug.LogWarning($"Animal ID {id} does not exist.");
            return null;
        }
    }

    private void loadAnimals()
    {
        this.animals = new Dictionary<int, Animal>();

        string[] lines = animalsDB.ReadLines();
        foreach (string line in lines)
        {
            AnimalStore store = new AnimalStore();
            bool success = store.loadCSVLine(line);
            if (!success)
                continue;

            Animal animal = store.loadAnimal();
            this.animals[animal.id] = animal;
        }
    }

    private void writeAnimal(Animal animal)
    {
        AnimalStore store = new AnimalStore(animal);
        animalsDB.Write(store.createCSVLine());
    }
}
