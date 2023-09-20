using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBalance : MonoBehaviour
{
    public Text balanceText;
    private int playerBalance = 0;

    void Update()
    {
        balanceUpdate();
    }

    void addCoins(int coins)
    {
        playerBalance += coins;
        balanceUpdate();
    }
    void balanceUpdate()
    {
        playerBalance = PlayerPrefs.GetInt("Coins", 0);
        balanceText.text = "PawCoins: $" + playerBalance.ToString();
    }
}
