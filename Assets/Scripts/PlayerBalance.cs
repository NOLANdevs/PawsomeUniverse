using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBalance : MonoBehaviour
{
    public Text balanceText;
    public int playerBalance = 100;

    void Update()
    {
        balanceUpdate();
    }

    void addCoins (int coins)
    {
        playerBalance += coins;
        balanceUpdate();
    }

    void balanceUpdate()
    {
        balanceText.text = "PawCoins: $" + playerBalance.ToString();
    }
}