using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string startScene = "Main";

    public void PlayGame()
    {
        SceneManager.LoadScene(startScene);
    }

    public void QuitGame()
    {
        GameLogic.ForceQuit();
    }


}
