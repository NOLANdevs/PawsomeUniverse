using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpForce = 1f;
    public GameObject animatorHolder;

    private Animal animal;
    private Rigidbody2D rigidBody;
    private Animator animator;

    public static bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        animal = GetComponent<Animal>();
        rigidBody = GetComponent<Rigidbody2D>();
        animator = animatorHolder.GetComponent<Animator>(); // Get the animator from the animatorHolder
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            float x = Input.GetAxisRaw("Horizontal");
            Vector2 moveDirection = new Vector2(x, 0f); // Store move direction for idle check
            rigidBody.velocity = new Vector2(x * moveSpeed, rigidBody.velocity.y);

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
                Jump();
            }

            CheckIdle(moveDirection);
        }
    }

    public void CheckIdle(Vector2 moveDirection)
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
        const float almostZero = 0.02f;
        if (Mathf.Abs(rigidBody.velocity.y) < almostZero)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }
    }
}
