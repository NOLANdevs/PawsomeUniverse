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
    public GameObject[] items;

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
        // Check if existing already
        if (!GameObject.FindWithTag("Food"))
        {
            Instantiate(items[index], items[index].transform.position, items[index].transform.rotation);
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
