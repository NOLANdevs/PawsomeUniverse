using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectOrientation : MonoBehaviour
{
    // The threshold angle for considered as "fallen over"
    public float fallThresholdAngle = 45f;
    // The speed
    public float rightingSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        GetUp();
    }

    private void GetUp()
    {
        // Check if rotation is not upright
        if (Mathf.Abs(transform.rotation.eulerAngles.z) > fallThresholdAngle)
        {
            // Calculate the target rotation (upright)
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, 0f);

            // Smoothly interpolate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rightingSpeed * Time.deltaTime);
        }
    }
}
