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
        Blue,
        Cyan,
        Green,
        Orange,
        Pink,
        Purple,
        Red,
        Yellow,
    }

    // metadata
    public int id;
    public string animalName;
    // Enum value
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

    // Game vars
    public SpriteRenderer[] petSprites;
    public Dictionary<Colour, Color> mapOfColours = new Dictionary<Colour, Color>();

    void Awake()
    {
        System.Random random = new System.Random();
        // Set random ID if it is not manually set
        if (id == 0)
            id = random.Next(10000, 99999 + 1); // random 5-digit ID
    }

    void Start()
    {
        convertColourToDict();
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

    // Makes a dictionary with according rgb values to the enum keys
    public void convertColourToDict()
    {
        foreach (Colour colour in Enum.GetValues(typeof(Colour)))
        {
            switch (colour)
            {
                case Colour.Blue:
                    Color blue = new Color(57f / 255f, 131f / 255f, 255f / 255f);
                    mapOfColours.Add(Colour.Blue, blue);
                    break;
                case Colour.Cyan:
                    Color cyan = new Color(94f / 255f, 254f / 255f, 254f / 255f);
                    mapOfColours.Add(Colour.Cyan, cyan);
                    break;
                case Colour.Green:
                    Color green = new Color(132f / 255f, 221f / 255f, 105f / 255f);
                    mapOfColours.Add(Colour.Green, green);
                    break;
                case Colour.Orange:
                    Color orange = new Color(255f / 255f, 132f / 255f, 50f / 255f);
                    mapOfColours.Add(Colour.Orange, orange);
                    break;
                case Colour.Pink:
                    Color pink = new Color(217f / 255f, 118f / 255f, 204f / 255f);
                    mapOfColours.Add(Colour.Pink, pink);
                    break;
                case Colour.Purple:
                    Color purple = new Color(141f / 255f, 61f / 255f, 255f / 255f);
                    mapOfColours.Add(Colour.Purple, purple);
                    break;
                case Colour.Red:
                    Color red = new Color(255f / 255f, 79f / 255f, 79f / 255f);
                    mapOfColours.Add(Colour.Red, red);
                    break;
                case Colour.Yellow:
                    Color yellow = new Color(252f / 255f, 255f / 255f, 66f / 255f);
                    mapOfColours.Add(Colour.Yellow, yellow);
                    break;

            }
        }
    }

    public void assignColour(int value)
    {
        colour = (Colour)value;

        foreach (SpriteRenderer sprite in petSprites)
        {
            sprite.color = mapOfColours[colour];
        }
    }

}
