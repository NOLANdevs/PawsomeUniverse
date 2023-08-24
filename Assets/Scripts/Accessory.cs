using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessory : MonoBehaviour
{
    public enum Colour
    {
        Black,
        White,
    }

    public enum Type
    {
    }

    public Colour colour;
    public Type type;

    private Sprite sprite;

}
