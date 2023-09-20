using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBalance : MonoBehaviour
{
    public Text balanceText;

    private void Start()
    {
        // initialise coins
        PlayerPrefs.SetInt("Coins", 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) // testing
        {
            addCoins(10);
        }
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
