using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    public static bool isPaused = false; // Whether the game is paused or not

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            // TODO pause menu!
            Debug.Log(isPaused);
        }
    }

}
