using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    public SpriteRenderer[] petSprites;

    private Animal animal;
    // Start is called before the first frame update
    void Start()
    {
        animal = GetComponent<Animal>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (SpriteRenderer sprite in petSprites)
            {
                sprite.color = animal.mapOfColours[animal.colour];
            }
        }
    }
}
