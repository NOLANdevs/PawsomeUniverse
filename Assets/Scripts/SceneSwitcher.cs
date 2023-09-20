using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToLoad;

    // Button press activate
    private void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast to mouse
            // If intersects, then the button is pressed
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }

    // Collision activate
    private void OnCollisionEnter2D(Collision2D other)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
