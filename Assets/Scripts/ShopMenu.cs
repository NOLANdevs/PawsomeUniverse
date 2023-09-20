using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    private Button buyButton;
    private int maxIndex = 10;
    private int minIndex = 0;
    private int index = 0;
    public List<ShopItemData> items;

    private int playerBalance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnItem()
    {
        GameObject itemPrefab = items[index].itemPrefab; // Get the item's prefab from ShopItemData
        Instantiate(itemPrefab, itemPrefab.transform.position, itemPrefab.transform.rotation);

    }


    public void BuyItem()
    {
        playerBalance = PlayerPrefs.GetInt("Coins", 0);

        if (!GameObject.FindWithTag("Food") && playerBalance >= items[index].itemPrice)
        {
            SpawnItem();

            // Deduct the item cost from the player's balance.
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) - items[index].itemPrice);
            Debug.Log(PlayerPrefs.GetInt("Coins", 0));
        }
    }


    public void NextItem()
    {
        if (index + 1 < 10)
        {
            index++;
        }
    }

    public void PrevItem()
    {
        if (index - 1 > 0)
        {
            index--;
        }
    }
}
