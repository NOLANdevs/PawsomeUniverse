using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to load

    private void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse pos in world coordinates
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //  Raycast to see if hit any gameobjects
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            // If hit a gameobject, check to see if its this gameobject
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // load scene
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
