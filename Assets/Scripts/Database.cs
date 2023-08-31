using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Database : MonoBehaviour
{

    public Animal animal; // testing
    public string dbFileName = "database.db";

    private string dbFilePath = "./Database/";
    private string fullPath;

    void Start()
    {
        init();
    }

    public void init()
    {
        fullPath = Path.Combine(dbFilePath, dbFileName);
        if (!Directory.Exists(dbFilePath))
        {
            Directory.CreateDirectory(dbFilePath);
        }

        write("");
        save(animal); // testing
    }

    public void save(Animal animal)
    {
        write($"{animal.id},{animal.animalName},{animal.species},{animal.colour},{animal.love},{animal.hunger},{animal.cleanliness}\n");
    }

    public void load(int id)
    {
    }

    private void write(string data)
    {
        File.WriteAllText(fullPath, data);
    }

}
