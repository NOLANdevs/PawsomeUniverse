using UnityEngine;

public class PawManager : MonoBehaviour
{
    public LoveBar loveBar;
    public Item pawItem;

    [SerializeField] private AudioSource petSound;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (loveBar != null && other.gameObject.CompareTag("Player"))
        {
            if (!(other.GetComponent<Animal>().isDragged))
            {
                petSound.Play();
                loveBar.PetAnimal(pawItem.statsIncreaseAmount);
            }       
        }
    }
}
