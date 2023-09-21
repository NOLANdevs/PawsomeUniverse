using UnityEngine;

public class ShowerManager : MonoBehaviour
{
    public CleanBar cleanBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (cleanBar != null)
            {
                int cleanlinessIncreaseAmount = 1;
                cleanBar.CleanAnimal(cleanlinessIncreaseAmount);
            }

        }
    }
}
