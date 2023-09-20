using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Database : MonoBehaviour
{

    public Animal animal;
    public string dbFileName = "database.db";

    private string dbFilePath = "./Database/";
    private string fullPath;
    private Dictionary<string, Animal> animals;

    void Start()
    {
        this.init();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // testing
        {
            this.saveAnimal(this.animal);
        }
    }

    public void Save()
    {
        this.saveDatabase();
    }

    public void init()
    {
        fullPath = Path.Combine(dbFilePath, dbFileName);
        if (!Directory.Exists(dbFilePath))
        {
            Directory.CreateDirectory(dbFilePath);
        }

        this.writeLine("");
        this.loadAnimals();
    }

    public void saveAnimal(Animal animal)
    {
        animals[animal.id] = animal;
        this.saveDatabase();
    }

    public Animal loadAnimal(string id)
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

    public void loadAnimals()
    {
        this.animals = new Dictionary<string, Animal>();
        try
        {
            string[] lines = this.readLines();
            foreach (string line in lines)
            {
                AnimalStore store = new AnimalStore();
                store.loadCSVLine(line);

                Animal animal = store.loadAnimal();
                this.animals[animal.id] = animal;
                Debug.Log($"Loaded animal {animal.id}");
            }
        }
        catch (FileNotFoundException)
        {
            Debug.Log("Database not yet created.");
        }
        catch (IOException ex)
        {
            Debug.Log("An error occurred: " + ex.Message);
        }
    }

    private void saveDatabase()
    {
        animals[animal.id] = animal;

        this.clearLines();
        foreach (Animal animal in animals.Values)
        {
            this.writeAnimal(animal);
        }
    }

    private void writeAnimal(Animal animal)
    {
        AnimalStore store = new AnimalStore(animal);
        this.writeLine(store.createCSVLine());
    }

    private void writeLine(string data)
    {
        File.AppendAllText(fullPath, data);
        Debug.Log($"Wrote {data} to {fullPath}");
    }

    private void clearLines()
    {
        File.WriteAllText(fullPath, "");
    }

    private string[] readLines()
    {
        return File.ReadAllLines(fullPath);
    }

}
