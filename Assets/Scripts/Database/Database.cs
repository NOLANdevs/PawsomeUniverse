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

    public string Read()
    {
        return string.Join("\n", ReadLines());
    }

    public string[] ReadLines()
    {
        return File.ReadAllLines(dbFullPath);
    }

    public void Write(string data)
    {
        File.AppendAllText(dbFullPath, data);
    }

    public void WriteLines(List<string> data)
    {
        Write(string.Join("\n", data) + "\n");
    }

    public void Clear()
    {
        File.WriteAllText(dbFullPath, "");
    }

    public void Deduplicate(int idCol)
    {
        List<string> allLines = new List<string>(ReadLines());
        HashSet<string> uniqueIDs = new HashSet<string>();
        List<string> uniqueLines = new List<string>();

        allLines.Reverse();

        // Loop through all lines
        foreach (string line in allLines)
        {
            string[] parts = line.Split(",");
            // Skip if empty line
            if (parts.Length == 0) continue;

            // Get ID from the stated column
            string id = parts[idCol];
            if (!uniqueIDs.Contains(id))
            {
                // ID is not in the set, so add it to the set and add the line to the unique list
                uniqueIDs.Add(id);
                uniqueLines.Add(line);
            }
        }

        uniqueLines.Reverse();

        // Write back to file
        Clear();
        WriteLines(uniqueLines);
    }

}
