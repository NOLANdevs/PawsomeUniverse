using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Database : ScriptableObject
{

    public string dbFileName = "database.db";

    private string dbFilePath = "./Database/";
    private string fullPath;

    public void Init()
    {
        this.fullPath = Path.Combine(dbFilePath, dbFileName);
        if (!Directory.Exists(dbFilePath))
        {
            Directory.CreateDirectory(dbFilePath);
        }

        this.Write("");
    }

    public string[] ReadLines()
    {
        return File.ReadAllLines(fullPath);
    }

    public void Write(string data)
    {
        File.AppendAllText(fullPath, data);
        Debug.Log($"Wrote {data} to {fullPath}");
    }

    public void Clear()
    {
        File.WriteAllText(fullPath, "");
    }

}
