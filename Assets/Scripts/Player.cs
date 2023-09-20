using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int money;
    public Animal animal;
    public HungerBar hungerBar;

    public CleanBar cleanBar;
    public Inventory inventory;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for collisions
        if (collision.gameObject.CompareTag("Food"))
        {
            hungerBar.FeedAnimal(1);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Shower"))
        {
            // Check if the player collides with a shower object
            cleanBar.CleanAnimal(1);
        }
    }

}
