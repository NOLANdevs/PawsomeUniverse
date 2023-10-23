using UnityEngine;
using UnityEngine.UI;

public class AccessoryImageDisplay : MonoBehaviour
{
    public Image mainImage;

    [SerializeField] private AudioSource selectSound;

    private void Start()
    {
        mainImage = GetComponent<Image>();

    }
    public void DisplayAccessoryImage(Sprite accessorySprite)
    {
        if (selectSound != null){
            selectSound.Play();
        }
        mainImage.preserveAspect = true;
        // set to display image
        mainImage.sprite = accessorySprite;
    }
}
