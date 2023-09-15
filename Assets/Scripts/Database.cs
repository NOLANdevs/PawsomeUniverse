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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // testing
        {
            save(animal);
        }
    }

    public void init()
    {
        fullPath = Path.Combine(dbFilePath, dbFileName);
        if (!Directory.Exists(dbFilePath))
        {
            Directory.CreateDirectory(dbFilePath);
        }

        write("");
    }

    public void save(Animal animal)
    {
        List<string> values = new List<string>
        {
            animal.id.ToString(),
            animal.animalName,
            animal.species.ToString(),
            animal.colour.ToString(),
            animal.love.ToString(),
            animal.hunger.ToString(),
            animal.cleanliness.ToString()
        };
        string writeStr = string.Join(",", values);
        write($"{writeStr}\n");
    }

    public void load(int id)
    {
    }

    private void write(string data)
    {
        File.WriteAllText(fullPath, data);
    }

}
