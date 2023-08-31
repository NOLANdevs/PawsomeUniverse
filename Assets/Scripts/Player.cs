using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int money;
    public Animal animal;
    public HungerBar hungerBar;
    public Inventory inventory;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            hungerBar.FeedAnimal(1);
            Destroy(collision.gameObject);
        }
    }
}
