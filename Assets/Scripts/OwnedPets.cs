using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnedPets : MonoBehaviour
{

    public AnimalDBManager animalDB;
    public List<Animal> animals;

    void Start()
    {
        animals = animalDB.getAnimals();
    }

    void Update()
    {
        return;
        foreach (var animal in animals)
        {
            Debug.Log(animal.id);
        }
    }
}
