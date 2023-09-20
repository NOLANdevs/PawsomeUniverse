using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Database : ScriptableObject
{
    private const string dbFilePath = "./Database/";

    private string dbFullPath;

    public void Init(string dbFileName)
    {
        this.dbFullPath = Path.Combine(dbFilePath, dbFileName);
        if (!Directory.Exists(dbFilePath))
        {
            Directory.CreateDirectory(dbFilePath);
        }

        this.Write("");
    }

    public string[] ReadLines()
    {
        return File.ReadAllLines(dbFullPath);
    }

    public void Write(string data)
    {
        File.AppendAllText(dbFullPath, data);
    }

    public void Clear()
    {
        File.WriteAllText(dbFullPath, "");
    }

}
