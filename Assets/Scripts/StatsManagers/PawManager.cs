using UnityEngine;

public class PawManager : MonoBehaviour
{
    public LoveBar loveBar;
    public Item pawItem;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (loveBar != null && collision.gameObject.CompareTag("Player"))
        {
            loveBar.PetAnimal(pawItem.statsIncreaseAmount);
        }
    }
}
