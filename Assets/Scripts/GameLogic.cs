using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static bool isPaused = false; // Whether the game is paused or not

    void Update()
    {
        // Pause game when Escape pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        // Halt all physics when game is paused
        Time.timeScale = isPaused ? 0 : 1; // set progression of time percentage: 0% if paused, 100% if not
    }

    public void PauseGame()
    {
        isPaused = false;
    }

    public void UnpauseGame()
    {
        isPaused = false;
    }

    public void ForceQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
