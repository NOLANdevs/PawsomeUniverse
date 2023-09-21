using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int money;
    public GameObject animatorHolder;
    public Animal animal;
    public HungerBar hungerBar;
    public LoveBar loveBar;
    public Inventory inventory;
    public float eatingTime = 0.1f;

    private Animator animator;
    private float timeSinceStartedEating = 0f;

    public void Start()
    {
        animal = GetComponent<Animal>();
        animator = animatorHolder.GetComponent<Animator>();
    }

    private void Update()
    {
        timeSinceStartedEating += Time.deltaTime;
        if (timeSinceStartedEating > eatingTime)
        {
            animal.isEating = false;
            animator.SetBool("IsEating", false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Item itemComponent = collision.gameObject.GetComponent<Item>();
        // Check for collisions
        if (collision.gameObject.CompareTag("Food"))
        {
            hungerBar.FeedAnimal(itemComponent.statsIncreaseAmount);
            Destroy(collision.gameObject);
            animal.isEating = true;
            animator.Play("eatfrog");
            animator.SetBool("IsEating", true);
            timeSinceStartedEating = 0;
        }
        else if (collision.gameObject.CompareTag("Brush"))
        {
            // Check if the player collides with a brush object
            loveBar.PetAnimal(0.1f); // TODO move to BrushManager
        }
    }

}
