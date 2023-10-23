using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    void Update()
    {
        // Check if the pause menu is active
        if (pauseMenu.activeSelf)
        {
            // if active check for esc press to close
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                BackToGame();
            }
        }
        else
        {
            // if not active check for esc press to open
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameLogic.PauseGame();
                pauseMenu.SetActive(true);
            }
        }
    }

    public void BackToGame()
    {
        if (pauseMenu.activeSelf)
        {
            GameLogic.UnpauseGame();
            pauseMenu.SetActive(false);
        }
    }
}
