using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    void Update()
    {
        // Pause game when Escape pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameLogic.PauseGame();
            pauseMenu.SetActive(true);
        }
    }

    public void BackToGame()
    {
        GameLogic.UnpauseGame();
        pauseMenu.SetActive(false);
    }
}
