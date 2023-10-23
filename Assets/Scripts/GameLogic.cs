using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static bool isPaused = false; // Whether the game is paused or not

    public static Animal activeAnimal; // The current animal character

    void Start()
    {
        setActiveAnimal();
    }

    void Update()
    {
        // Halt all physics when game is paused
        Time.timeScale = isPaused ? 0 : 1; // set progression of time percentage: 0% if paused, 100% if not

        // Ensure active animal is set
        setActiveAnimal();
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

    private static void setActiveAnimal()
    {
        activeAnimal = GameObject.FindWithTag("Player").GetComponent<Animal>();
    }
}
