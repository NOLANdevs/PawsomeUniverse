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

    public Sprite hungrySprite;
    public Sprite dirtySprite;
    public Sprite sadSprite;

    public SpriteRenderer stomachGrowlRenderer; // Reference to the SpriteRenderer component
    public SpriteRenderer dirtyMarksRenderer; // Reference to the SpriteRenderer component
    public SpriteRenderer eyebrowsRenderer; // Reference to the SpriteRenderer component

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

    public GameObject findGameObject(string name)
    {
        GameObject foundObject = GameObject.Find(name);
        if (foundObject == null)
        {
            Debug.LogWarning("GameObject not found: " + name);
        }
        return foundObject;
    }



public void Update()
{
    if (stomachGrowlRenderer == null)
    {
        stomachGrowl = findGameObject("StomachGrowl");
        stomachGrowlRenderer = stomachGrowl.GetComponent<SpriteRenderer>();
    }
    if (dirtyMarksRenderer == null)
    {
        dirtyMarks = findGameObject("DirtyMarks");
        dirtyMarksRenderer = dirtyMarks.GetComponent<SpriteRenderer>();
    }
    if (eyebrowsRenderer == null)
    {
        eyebrows = findGameObject("eyebrows");
        eyebrowsRenderer = eyebrows.GetComponent<SpriteRenderer>();
    }

    isHungry = hunger < 0.1f;
    isSad = love < 0.1f;
    isDirty = cleanliness < 0.1f;

    if (stomachGrowlRenderer != null)
    {
        stomachGrowlRenderer.sprite = isHungry ? hungrySprite : hungrySprite;
    }

    if (dirtyMarksRenderer != null)
    {
        dirtyMarksRenderer.sprite = isDirty ? dirtySprite : null;
    }

    if (eyebrowsRenderer != null)
    {
        eyebrowsRenderer.sprite = isSad ? sadSprite : null;
    }
}

}
