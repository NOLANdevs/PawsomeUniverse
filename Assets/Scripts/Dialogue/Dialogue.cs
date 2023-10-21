using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [TextArea(2, 3)]
    public string[] sentences;
    public string[] playerResponse;
}
