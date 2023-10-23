using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static bool isPaused = false; // Whether the game is paused or not

    void Update()
    {
        // Halt all physics when game is paused
        Time.timeScale = isPaused ? 0 : 1; // set progression of time percentage: 0% if paused, 100% if not
    }

    public static void PauseGame()
    {
        isPaused = true;
    }

    public static void UnpauseGame()
    {
        isPaused = false;
    }

    public static void ForceQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
