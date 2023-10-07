using UnityEngine;

public class ClickToBall : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded = true;
    public float force = 3;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        if (isGrounded)
        {
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
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * hitForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
}
