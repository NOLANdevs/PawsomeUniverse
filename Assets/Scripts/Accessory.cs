using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accessory : MonoBehaviour
{
    public enum Colour
    {
        Black,
        White,
    }

    public enum Type
    {
        Hat,
        Ears,
        Glasses,
        TallHat,
    }

    public Colour colour;
    public Type type;

    public string description; 
    public string title;
    public bool isEquipped; 
    public Sprite accessorySprite;

}
