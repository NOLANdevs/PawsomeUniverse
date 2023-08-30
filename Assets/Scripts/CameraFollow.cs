using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject characterToFollow;
    public float followSpeed = 5;
    public float zoomPower = 1;
    public Bounds yBounds = new Bounds(float.NegativeInfinity, float.PositiveInfinity);
    public Bounds zoomBounds = new Bounds(1, 5);

    new private Camera camera;
    private Vector3 center;
    private float baseZoom;

    void Start()
    {
        camera = GetComponent<Camera>();
        baseZoom = camera.orthographicSize;
        center = characterToFollow.transform.position; // set center to player's spawn point
    }

    void Update()
    {
        Vector3 playerPos = characterToFollow.transform.position;
        Vector3 camPos = transform.position;

        // Interpolate camera position to follow player position
        Vector3 newPos = Vector3.Lerp(camPos, playerPos, followSpeed * Time.deltaTime);
        // Clamp Y position to be between min and max Y
        newPos.y = Mathf.Clamp(newPos.y, yBounds.min, yBounds.max);
        // Zoom out camera when away from center
        float distFromCenter = Vector3.Distance(playerPos, center);
        float zoomAmount = Mathf.Pow(distFromCenter, zoomPower);
        Debug.Log(zoomAmount);
        camera.orthographicSize = Mathf.Clamp(zoomAmount, zoomBounds.min, zoomBounds.max);
        // move camera
        newPos.z = camPos.z;
        transform.position = newPos;
    }
}

[System.Serializable] // This attribute allows the struct to be shown in the Inspector
public struct Bounds
{
    public float min, max;

    public Bounds(float min, float max)
    {
        this.min = min;
        this.max = max;
    }
}
