using UnityEngine;

public class ShowerManager : MonoBehaviour
{
    public CleanBar cleanBar;
    public Item showerItem;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (cleanBar != null && collision.gameObject.CompareTag("Player"))
        {
            cleanBar.CleanAnimal(showerItem.statsIncreaseAmount);
        }
    }
}
