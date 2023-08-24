using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float moveSpeed = 1f;

    void Update()
    {
        // get user input
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        // calculate movement vector
        Vector3 moveDirection = new Vector3(horiz, vert, 0f).normalized;

        // move character
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

}
