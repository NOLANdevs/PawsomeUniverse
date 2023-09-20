using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundaryTransition : MonoBehaviour
{
    public string targetSceneName; // The name of the target scene (Scene B)
    public string targetBoundaryTag; // The tag of the target boundary in Scene B

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Set a PlayerPrefs value to store the target boundary tag
            PlayerPrefs.SetString("TargetBoundaryTag", targetBoundaryTag);

            // Load the target scene
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
