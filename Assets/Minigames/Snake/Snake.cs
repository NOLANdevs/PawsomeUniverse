using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    // Movement
    private Vector2 direction = Vector2.right;
    private bool isAlive = true;

    // Segments
    private List<Transform> segments;
    public Transform segmentPrefab;
    //[SerializeField]public float segmentSpacing = 0.1f;
    
    // Scoring 
    public int playerScore = 0;
    public Text scoreText;

    // GameOver
    public GameObject gameOverScreen;
    private Database coinsDB;
    public string homeScene;


    private void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
    }

    private void Update()
    {
        // Change Direction based on key clicked
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isAlive)
        {
            direction = Vector2.up;
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && isAlive)
        {
            direction = Vector2.left;
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && isAlive)
        {
            direction = Vector2.down;
        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && isAlive)
        {
            direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            for (int i = segments.Count - 1; i > 0; i--)
            {
                segments[i].position = segments[i - 1].position;

                /*Vector3 newPos = segments[i - 1].position;

                // Apply segment spacing
                float distance = segmentSpacing;
                if (i == 1)
                {
                    distance = 1.0f;
                }

                segments[i].position = Vector3.Lerp(segments[i].position, newPos, Time.fixedDeltaTime * 10f);*/
            }

            this.transform.position = new Vector3(
                Mathf.Round(this.transform.position.x) + direction.x,
                Mathf.Round(this.transform.position.y) + direction.y,
                0.0f
            );
        }
    }

    public void GameOver()
    {
        isAlive = false;
        gameOverScreen.SetActive(true);
    }

    public void goHome()
    {
        int newCoins = PlayerPrefs.GetInt("Coins", 0) + playerScore;
        PlayerPrefs.SetInt("Coins", newCoins);
        PlayerPrefs.Save();

        if (coinsDB != null)
        {
            coinsDB.Clear();
            coinsDB.Write(newCoins.ToString());
        }

        SceneManager.LoadScene(homeScene);
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;

        segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            playerScore++;
            Grow();
        }
        else if (other.tag == "SnakeWalls")
        {
            GameOver();
        }
    }

    public void restart()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(this.transform);
        this.transform.position = Vector3.zero;
    }
}
