using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public enum Species
    {
        Frog,
        Octopus,
    }

    public enum Colour
    {
        Black,
        Green,
        Magenta,
        White,
    }

    // metadata
    public int id;
    public string animalName;
    public Colour colour;
    public Species species;

    // stats
    // values are from 0 to 1
    public float love = 0.5f;
    public float hunger = 0.5f;
    public float cleanliness = 0.5f;

    // items
    public Inventory inventory;
    public Accessory[] accessories;

    // statuses
    public bool isEating = false;

    public bool isHungry = false;

    public bool isSad = false;

    public bool isDirty = false;

    public bool isDragged = false;

    // Components
    public GameObject stomachGrowl = null;
    public GameObject dirtyMarks = null;
    public GameObject eyebrows = null;

    private Sprite sprite;

    void Awake()
    {
        // Set random ID if it is not manually set
        if (id == 0)
            id = Animal.ID();
    }

    void Start()
    {
    }

    // Generate a Random ID for the pet to have
    public static int ID()
    {
        System.Random random = new System.Random();
        return random.Next(10000, 99999 + 1); // random 5-digit ID
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



public void Update()
{

        isHungry = hunger < 0.1f;
        isSad = love < 0.1f;
        isDirty = cleanliness < 0.1f;

    // if stomachGrowl variable is assigned
        if (stomachGrowl){
            if(isHungry)
            {
                stomachGrowl.SetActive(true);
            }
            else
            {
                stomachGrowl.SetActive(false);
            }
        }
            // if dirty variable is assigned
        if (dirtyMarks){
            if(isDirty)
            {
                dirtyMarks.SetActive(true);
            }
            else
            {
                dirtyMarks.SetActive(false);
            }
}
    // if eyebrows variable is assigned
        if (eyebrows){
            if(isSad)
            {
                eyebrows.SetActive(true);
            }
            else
            {
                eyebrows.SetActive(false);
            }
        }  

}
}