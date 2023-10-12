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

    public float moveInterval = 0.1f;
    private float moveTimer = 0.0f;

    // Segments
    private List<Transform> segments;
    public Transform segmentPrefab;
    
    // Scoring 
    public int playerScore = 0;
    public int scoreIncrease = 1;
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
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isAlive && (direction != Vector2.down))
        {
            direction = Vector2.up;
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && isAlive && (direction != Vector2.right))
        {
            direction = Vector2.left;
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && isAlive && (direction != Vector2.up))
        {
            direction = Vector2.down;
        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && isAlive && (direction != Vector2.left))
        {
            direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            moveTimer += Time.fixedDeltaTime;

            if (moveTimer >= moveInterval)
            {
                for (int i = segments.Count - 1; i > 0; i--)
                {
                    segments[i].position = segments[i - 1].position;
                }

                this.transform.position = new Vector3(
                    Mathf.Round(this.transform.position.x) + direction.x,
                    Mathf.Round(this.transform.position.y) + direction.y,
                    0.0f
                );

                moveTimer = 0.0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        else if (other.tag == "SnakeWalls")
        {
            GameOver();
        }
    }

    private void Grow()
    {
        addScore(scoreIncrease);

        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;

        segments.Add(segment);
    }


    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void GameOver()
    {
        isAlive = false;

        this.transform.position = new Vector3(
                   Mathf.Round(this.transform.position.x) - direction.x,
                   Mathf.Round(this.transform.position.y) - direction.y,
                   0.0f
               );

        gameOverScreen.SetActive(true);
    }

    public void restart()
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) + playerScore);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
}
