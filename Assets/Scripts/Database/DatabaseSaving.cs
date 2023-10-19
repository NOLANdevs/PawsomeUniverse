using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseSaving : MonoBehaviour
{
    public IDatabaseManager[] databaseManagers;
    public int autosaveInterval = 60; // seconds
    public GameObject saveText;

    private float timeSinceLastSave = 0;

    void Start()
    {
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

        // save each database
        foreach (var db in databaseManagers)
        {
            db.Save();
        }
    }

}
