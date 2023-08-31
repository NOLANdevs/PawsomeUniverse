using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject characterToFollow;
    public float followSpeed = 5;
    public float zoomPower = 1;
    public float lingerTime = 2;
    public float lingerSmoothness = 3;
    public Bounds yBounds = new Bounds(float.NegativeInfinity, float.PositiveInfinity);
    public Bounds zoomBounds = new Bounds(1, 5);

    new private Camera camera;
    private Vector3 center;
    private float baseZoom;
    private float targetOrthoSize;
    private float timeSinceLastInteraction;

    void Start()
    {
        camera = GetComponent<Camera>();
        center = characterToFollow.transform.position; // set center to player's spawn point
        baseZoom = camera.orthographicSize;
        targetOrthoSize = camera.orthographicSize;
        timeSinceLastInteraction = lingerTime;
    }

    void Update()
    {
        timeSinceLastInteraction += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            timeSinceLastInteraction = 0f;
        }

        Vector3 playerPos = characterToFollow.transform.position;
        Vector3 camPos = transform.position;

        // Interpolate camera position to follow player position
        Vector3 newPos = Vector3.Lerp(camPos, playerPos, followSpeed * Time.deltaTime);
        // Clamp Y position to be between min and max Y
        newPos.y = Mathf.Clamp(newPos.y, yBounds.min, yBounds.max);
        // Move camera
        transform.position = new Vector3(newPos.x, newPos.y, camPos.z);

        // Zoom out camera when away from center
        float distFromCenter = Vector3.Distance(playerPos, center);
        float zoomAmount = Mathf.Pow(distFromCenter, zoomPower);
        targetOrthoSize = Mathf.Clamp(zoomAmount, zoomBounds.min, zoomBounds.max);

        // Move camera to include interactable object for a period of time when it has been recently clicked
        if (timeSinceLastInteraction < lingerTime)
        {
            Vector3 clickPosition = camera.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0;
            float distanceToClick = Vector3.Distance(camPos, clickPosition);
            float newOrthoSize = distanceToClick * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
            targetOrthoSize = Mathf.Clamp(newOrthoSize, zoomBounds.min, zoomBounds.max);
        }

        // Smoothly transition the orthographic size to the target size
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetOrthoSize, lingerSmoothness * Time.deltaTime);
    }
}

[System.Serializable] // displayable in inspector
public struct Bounds
{
    public float min, max;

    public Bounds(float min, float max)
    {
        this.min = min;
        this.max = max;
    }
}
