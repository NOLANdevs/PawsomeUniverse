using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformerLogic : MonoBehaviour
{
    public GameObject GameOverScreen;

    // Start is called before the first frame update
    public void gameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        GameOverScreen.SetActive(true);
    }
}
