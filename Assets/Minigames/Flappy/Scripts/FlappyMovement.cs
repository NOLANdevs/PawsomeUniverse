using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public LogicScript logic;
    public Animator flap_animator;

    [SerializeField] int jumpMultiplier = 5;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && logic.isAlive)
        {
            myRigidbody.velocity = Vector2.up * jumpMultiplier;
            flap_animator.SetTrigger("Flap");
        }

        if (transform.position.y >= 20 || transform.position.y <= -20)
        {
            kill();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        kill();
    }

    private void kill()
    {
        logic.gameOver();
        logic.isAlive = false;
    }
}
