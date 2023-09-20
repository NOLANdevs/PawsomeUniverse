using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public enum Species
    {
        Frog,
    }

    public enum Colour
    {
        Black,
        White,
        Green,
    }

    // metadata
    public int id;
    public string animalName;
    public Colour colour;
    public Species species;
    // stats
    // values are from 0 to 1
    public float love = 0;
    public float hunger = 0;
    public float cleanliness = 0;

    // items
    public Inventory inventory;
    public Accessory[] accessories;
    // statuses
    public bool isEating = false;

    private Sprite sprite;

    void Awake()
    {
        System.Random random = new System.Random();
        // Set random ID if it is not manually set
        if (id == 0)
            id = random.Next(10000, 99999 + 1); // random 5-digit ID
    }

    void Start()
    {
    }

    public void equipAccessory(Accessory accessory)
    {
    }

    public void useAmenity(Amenity amenity)
    {
    }

    public void Feed(int amount)
    {
        hunger += amount;
    }

}
