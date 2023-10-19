using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public bool isAlive = true;
    public string homeScene;

    private Database coinsDB;

    void Awake()
    {
        this.coinsDB = StatsDBManager.statsDB;
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) + playerScore);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void goHome()
    {
        int newCoins = PlayerPrefs.GetInt("Coins", 0) + playerScore;
        PlayerPrefs.SetInt("Coins", newCoins);
        PlayerPrefs.Save();

        if (coinsDB != null)
        {
            coinsDB.Clear();
            coinsDB.Write(newCoins.ToString());
        }

        SceneManager.LoadScene(homeScene);
    }
}
