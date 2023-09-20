using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseInterface : MonoBehaviour
{
    public Animal curAnimal;
    public int autosaveInterval = 60; // seconds
    public GameObject saveText;

    private Database animalsDB, statsDB;
    private Dictionary<int, Animal> animals;
    private float timeSinceLastSave = 0;

    void Start()
    {
        this.animalsDB = ScriptableObject.CreateInstance<Database>();
        this.statsDB = ScriptableObject.CreateInstance<Database>();
        animalsDB.Init("animals.db");
        statsDB.Init("stats.db");

        loadAnimals();
        loadStats();

        List<Animal> list = new List<Animal>(this.animals.Values);
        if (list.Count > 0)
        {
            Animal selected = list[0]; // default to first animal for now
            applyToPlayer(selected);
        }
    }

    void Update()
    {
        // Autosaving
        timeSinceLastSave += Time.deltaTime;
        if (timeSinceLastSave > autosaveInterval)
        {
            Save();
        }

        // Hide saving text after 1 second
        if (timeSinceLastSave > 1)
        {
            saveText.SetActive(false);
        }
    }

    public void Save()
    {
        // show save text
        timeSinceLastSave = 0;
        saveText.SetActive(true);

        // save current animal to loaded list
        storeCurAnimal();

        // save to DB
        saveAnimals();
        saveStats();
    }

    private void applyToPlayer(Animal selected)
    {
        AnimalStore store = new AnimalStore(selected);
        store.applyToAnimal(this.curAnimal);
    }

    private void storeCurAnimal()
    {
        animals[this.curAnimal.id] = this.curAnimal;
    }

    private void saveAnimals()
    {
        animalsDB.Clear();
        foreach (Animal animal in animals.Values)
        {
            writeAnimal(animal);
        }

        Debug.Log($"Saved {animals.Count} animals to database.");
    }

    private Animal loadAnimal(int id)
    {
        if (this.animals.ContainsKey(id))
        {
            Debug.Log($"Loaded animal {id} from database.");
            return this.animals[id];
        }
        else
        {
            Debug.Log($"Animal ID {id} does not exist.");
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
        Debug.Log($"Loaded {this.animals.Count} animals from database.");
    }

    private void writeAnimal(Animal animal)
    {
        AnimalStore store = new AnimalStore(animal);
        animalsDB.Write(store.createCSVLine());
    }

    private void saveStats()
    {
        statsDB.Clear();
        statsDB.Write(PlayerPrefs.GetInt("Coins").ToString());
    }

    private void loadStats()
    {
        PlayerPrefs.SetInt("Coins", int.Parse(statsDB.Read()));
    }

}
