using UnityEngine;

public class BrushManager : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    public LoveBar loveBar; // Reference to the LoveBar script


    private void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, 0f);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // The Paw hits the player increase love using the LoveBar script
            if (loveBar != null)
            {
                float loveIncreaseAmount = 1f;
                loveBar.PetAnimal(loveIncreaseAmount);
            }

        }
    }
}
