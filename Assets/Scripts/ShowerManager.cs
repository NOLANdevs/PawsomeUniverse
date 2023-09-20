using UnityEngine;

public class ShowerManager : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    public CleanBar cleanBar; // Reference to the CleanBar script


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
            // The shower hits the player increase cleanliness using the CleanBar script
            if (cleanBar != null)
            {
                int cleanlinessIncreaseAmount = 1;
                cleanBar.CleanAnimal(cleanlinessIncreaseAmount);
            }

        }
    }
}
