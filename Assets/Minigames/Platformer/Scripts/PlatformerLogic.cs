using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlatformerLogic : MonoBehaviour
{
    public Text scoreText;
    public GameObject GameOverScreen;
    public GameObject animatorHolder;
    private Database coinsDB;
    public string homeScene;

    void Awake()
    {
        this.coinsDB = DatabaseInterface.statsDB;
        PlatformerMovement.isAlive = true;
    }

    private void Update()
    {
        scoreText.text = "Strawberries: " + StrawberryCollection.strawberry.ToString();
    }

    public void addScore(int scoreToAdd)
    {
        StrawberryCollection.strawberry += scoreToAdd;
    }

    public void gameRestart()
    {
        PlatformerMovement.isAlive = true;
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) + StrawberryCollection.strawberry);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    { 
        PlatformerMovement.isAlive = false;
        GameOverScreen.SetActive(true);
    }

    public void goHome()
    {
        int newCoins = PlayerPrefs.GetInt("Coins", 0) + StrawberryCollection.strawberry;
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
