using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBalance : MonoBehaviour
{
    public Text balanceText;
    public int defaultBalance = 100;

    private void Start()
    {
        // initialise coins to the default balance if not loaded from database
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", defaultBalance));
    }

    void Update()
    {
        balanceUpdate();
    }

    void addCoins(int coins)
    {
        int playerBalance = PlayerPrefs.GetInt("Coins", 0);
        playerBalance += coins;
        PlayerPrefs.SetInt("Coins", playerBalance);
        balanceUpdate();
    }

    void balanceUpdate()
    {
        int playerBalance = PlayerPrefs.GetInt("Coins", 0);
        balanceText.text = "PawCoins: $" + playerBalance.ToString();
    }
}
