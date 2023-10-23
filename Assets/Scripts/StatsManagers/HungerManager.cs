using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerManager : MonoBehaviour
{

    public Animal animal;
    public GameObject animatorHolder;
    public HungerBar hungerBar;
    public float eatingTime = 0.1f;

    private Animator animator;
    private float timeSinceStartedEating = 0f;

    [SerializeField] private AudioSource eatSound;

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
            eatSound.Play();
            Destroy(collision.gameObject);
            animal.isEating = true;
            animator.Play("eatfrog");
            animator.SetBool("IsEating", true);
            timeSinceStartedEating = 0;
        }
    }

}
