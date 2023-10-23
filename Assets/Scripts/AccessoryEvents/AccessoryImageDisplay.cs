using UnityEngine;
using UnityEngine.UI;

public class AccessoryImageDisplay : MonoBehaviour
{
    public Image mainImage; 

       private void Start()
    {
        mainImage = GetComponent<Image>();

    }
    public void DisplayAccessoryImage(Sprite accessorySprite)
    {
            mainImage.preserveAspect = true;
            // set to display image
            mainImage.sprite = accessorySprite;
    }
}
