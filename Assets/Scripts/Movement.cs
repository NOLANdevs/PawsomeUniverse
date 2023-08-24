using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float jumpForce = 1f;

    private Rigidbody2D rigidBody;

    private Animator animator;
    public GameObject frogAnimatorHolder;

    private bool isEating = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = frogAnimatorHolder.GetComponent<Animator>(); // Get the animator from the frogAnimatorHolder

    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 moveDirection = new Vector2(x, 0f); // Store move direction for idle check
        rigidBody.velocity = new Vector2(x * moveSpeed, rigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        checkEat();
        checkIdle(moveDirection);

    }

    private void checkEat()
    {
        // press e to eat
        if (Input.GetKey(KeyCode.E))
        {
            isEating = true;
        }
        else
        {
            isEating = false;
        }

        animator.SetBool("IsEating", isEating);

        // while frog is eating it cannot move horizontally
        if (isEating)
        {
            animator.SetBool("IsEating", true);
            rigidBody.velocity = new Vector2(0f, rigidBody.velocity.y); // Maintain vertical velocity
            return;
        }
    }
    private void checkIdle(Vector2 moveDirection)
    {
        // Check if the frog is not moving
        if (moveDirection.magnitude <= 0.1f)
        {
            animator.SetBool("IsIdle", true);
        }
        else
        {
            animator.SetBool("IsIdle", false);
        }
    }


    private void Jump()
    {
        const float almostZero = 0.1f;
        if (Mathf.Abs(rigidBody.velocity.y) < almostZero)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }
    }
}