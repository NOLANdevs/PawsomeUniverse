using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StatsDBManager : IDatabaseManager
{
    public static Database statsDB;

    void Awake()
    {
        statsDB = ScriptableObject.CreateInstance<Database>();
        statsDB.Init("stats.db");
    }

    void Start()
    {
        loadStats();
    }

    public override void Save()
    {
        saveStats();
    }

    private void saveStats()
    {
        statsDB.Clear();
        statsDB.Write(PlayerPrefs.GetInt("Coins").ToString());
    }

    private void loadStats()
    {
        try
        {
            PlayerPrefs.SetInt("Coins", int.Parse(statsDB.Read()));
        }
        catch (FormatException)
        {
            // leave Coins undefined
        }
    }
}
