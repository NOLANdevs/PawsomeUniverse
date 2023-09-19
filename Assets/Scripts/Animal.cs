using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public enum Species
    {
    }

    public enum Colour
    {
        Black,
        White,
    }

    // metadata
    public int id;
    public string animalName;
    public Colour colour;
    public Species species;
    // stats
    public float love;
    public float hunger = 0;
    public float cleanliness;

    public float maxCleanliness = 20;

    // items
    public Inventory inventory;
    public Accessory[] accessories;
    // statuses
    public bool isEating = false;

    private Sprite sprite;

    public void Start()
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
