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

    void Start()
    {
        init();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // testing
        {
            save(this.animal);
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
        string line = new AnimalStore(animal).createCSVLine();
        write(line);
    }

    public void load(int id)
    {
    }

    private void write(string data)
    {
        File.WriteAllText(fullPath, data);
        Debug.Log($"Wrote {data} to {fullPath}");
    }

    private string read()
    {
        return ""; // TODO
    }

}
