using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public float deadZone = -40;
    public float initialSpeed = 1.0f; // Initial speed of the object
    public float acceleration = 0.1f; // Rate at which speed increases

    private float currentSpeed;

    private void Start()
    {
        currentSpeed = initialSpeed;
    }

    void Update()
    {
        // Calculate the new position based on the current speed
        transform.position += Vector3.left * currentSpeed * Time.deltaTime;

        // Increase the speed over time
        currentSpeed += acceleration * Time.deltaTime;

        // Delete the pipe when offscreen
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}