using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int money;
    public GameObject animatorHolder;
    public Animal animal;
    public HungerBar hungerBar;
    private Animator animator;

    public CleanBar cleanBar;
    public Inventory inventory;
    public float statsIncrementAmount = 0.05f;

    public void Start()
    {
        animal = GetComponent<Animal>();
        animator = animatorHolder.GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for collisions
        if (collision.gameObject.CompareTag("Food"))
        {
            hungerBar.FeedAnimal(statsIncrementAmount);
            Destroy(collision.gameObject);
            animal.isEating = true;
            animator.SetTrigger("CheckEat");
        }
        else if (collision.gameObject.CompareTag("Shower"))
        {
            // Check if the player collides with a shower object
            cleanBar.CleanAnimal(statsIncrementAmount);
        }
        else
        {
            animal.isEating = false;
        }
    }

}
