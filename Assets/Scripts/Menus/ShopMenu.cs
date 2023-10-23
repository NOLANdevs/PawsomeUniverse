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
    public List<Item> items;

    private int playerBalance;

    [SerializeField] private AudioSource buySound;

    void Start()
    {
    }

    void Update()
    {
    }

    public void SpawnItem()
    {
        GameObject itemPrefab = items[index].prefab;
        Instantiate(itemPrefab, itemPrefab.transform.position, itemPrefab.transform.rotation);
    }

    public void BuyItem()
    {
        playerBalance = PlayerPrefs.GetInt("Coins", 0);

        if (!GameObject.FindWithTag("Food") && playerBalance >= items[index].price)
        {
            buySound.Play();
            SpawnItem();

            // Deduct the item cost from the player's balance.
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) - items[index].price);
        }
    }

    public void NextItem()
    {
        if (index + 1 < maxIndex)
        {
            index++;
        }
    }

    public void PrevItem()
    {
        if (index - 1 > minIndex)
        {
            index--;
        }
    }
}
