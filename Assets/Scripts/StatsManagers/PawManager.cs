using UnityEngine;

public class PawManager : MonoBehaviour
{
    public LoveBar loveBar;
    public Item pawItem;

    [SerializeField] private AudioSource petSound;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (loveBar != null && collision.gameObject.CompareTag("Player"))
        {
            petSound.Play();
            loveBar.PetAnimal(pawItem.statsIncreaseAmount);
        }
    }
}
