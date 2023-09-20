using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float jumpForce = 1f;
    public GameObject animatorHolder;

    private Animal animal;
    private Rigidbody2D rigidBody;
    private Animator animator;

    // The threshold angle for considering the player as "fallen over"
    public float fallThresholdAngle = 45f;

    // The speed the player gets up
    public float rightingSpeed = 5f;

    void Start()
    {
        animal = GetComponent<Animal>();
        rigidBody = GetComponent<Rigidbody2D>();
        animator = animatorHolder.GetComponent<Animator>(); // Get the animator from the animatorHolder
    }

    void Update()
    {
        // Do nothing if game is paused
        if (GameLogic.isPaused)
            return;

        float x = Input.GetAxisRaw("Horizontal");
        Vector2 moveDirection = new Vector2(x, 0f); // Store move direction for idle check
        rigidBody.velocity = new Vector2(x * moveSpeed, rigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        GetUp();
        CheckEat();
        CheckIdle(moveDirection);
    }
    // checks if player has fallen over and corrects it 
    private void GetUp()
    {
        // Check if the player's rotation is not upright
        if (Mathf.Abs(transform.rotation.eulerAngles.z) > fallThresholdAngle)
        {
            // Calculate the target rotation (upright)
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, 0f);

            // Smoothly interpolate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rightingSpeed * Time.deltaTime);
        }
    }

    private void CheckEat()
    {
        // press e to eat
        animal.isEating = Input.GetKey(KeyCode.E);
        animator.SetBool("IsEating", animal.isEating);

        if (animal.isEating)
        {
            animator.SetBool("IsEating", true);
        }

        // while frog is eating it cannot move horizontally
        if (animal.isEating)
        {
            rigidBody.velocity = new Vector2(0f, rigidBody.velocity.y); // Maintain vertical velocity
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
