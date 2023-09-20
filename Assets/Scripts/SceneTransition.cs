using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundaryTransition : MonoBehaviour
{
    public GameObject envToLoad;
    public GameObject envToUnload;
    public Vector3 playerSpawnPoint;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Toggle environments
            if (envToLoad != null)
                envToLoad.SetActive(true);
            if (envToUnload != null)
                envToUnload.SetActive(false);
            // Move player
            player.transform.parent.position = playerSpawnPoint;
        }
    }
}
