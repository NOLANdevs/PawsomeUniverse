using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject characterToFollow;
    public float followSpeed = 5;
    public float minY = float.NegativeInfinity;
    public float maxY = float.PositiveInfinity;

    void Start()
    {
    }

    void Update()
    {
        Vector3 playerPos = characterToFollow.transform.position;
        Vector3 camPos = transform.position;

        // Interpolate camera position onto player position and move camera to follow player
        Vector3 newPos = Vector3.Lerp(camPos, playerPos, followSpeed * Time.deltaTime);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY); // clamp to be between min and max Y
        transform.position = new Vector3(newPos.x, newPos.y, camPos.z);
    }
}
