using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Amenity : MonoBehaviour
{

    public enum Type
    {
        Love,
        Hunger,
        Clean,
    }

    public abstract float points { get; }

}
