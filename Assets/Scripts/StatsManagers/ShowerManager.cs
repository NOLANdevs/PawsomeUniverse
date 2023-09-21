using UnityEngine;

public class ShowerManager : MonoBehaviour
{
    public CleanBar cleanBar;
    public Item showerItem;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (cleanBar != null && other.gameObject.CompareTag("Player"))
        {
            cleanBar.CleanAnimal(showerItem.statsIncreaseAmount);
        }
    }
}

