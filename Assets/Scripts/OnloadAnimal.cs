using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnloadAnimal : MonoBehaviour
{
    public DatabaseInterface database;
    public Animal animalObject;

    void Start()
    {
        bool doNewPet = PlayerPrefs.GetInt("CreateNewPet", 0) == 1;
        // exit if a new pet is not being made
        if (doNewPet)
        {
            setNewPet();
            Debug.Log("setNewPet()");
        }
        else
        {
            setSavedPet();
            Debug.Log("setSavedPet");
        }

    }

    void Update()
    {
    }

    private void setNewPet()
    {
        string newPet = PlayerPrefs.GetString("NewPetType");
    }

    private void setSavedPet()
    {
        List<Animal> list = new List<Animal>(database.animals.Values);
        if (list.Count > 0)
        {
            Animal selected = list[0]; // default to first animal for now // TODO
            applyToPlayer(selected);
        }
    }

    private void applyToPlayer(Animal selected)
    {
        AnimalStore store = new AnimalStore(selected);
        store.applyToAnimal(this.animalObject);
    }
}
