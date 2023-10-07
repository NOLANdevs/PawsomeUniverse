using UnityEngine;

public class ClickToBall : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded = true;
    public float force = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        if (isGrounded) {
            HitBall(force);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void HitBall(float force)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
}
