using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnedPets : MonoBehaviour
{

    public DatabaseInterface database;
    public List<Animal> animals;

    void Start()
    {
        animals = new List<Animal>(database.animals.Values);
    }

    void Update()
    {
        foreach (var animal in animals)
        {
            Debug.Log(animal.id);
        }
    }
}
