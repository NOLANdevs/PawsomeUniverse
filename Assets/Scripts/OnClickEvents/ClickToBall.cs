using UnityEngine;

public class ClickToBall : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded = true;
    public float force = 3;
    private AudioSource audioSource;
    private bool canInteract = true; // Flag to control interactions

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (canInteract && isGrounded)
        {
            audioSource.Play();
            HitBall(force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void HitBall(float hitForce)
    {
        if (canInteract && isGrounded)
        {
            rb.AddForce(Vector2.up * hitForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    public void SetInteract(bool state)
    {
        canInteract = state;
    }
}
