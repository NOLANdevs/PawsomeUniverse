using UnityEngine;
using UnityEngine.UI;

public class SetAccessory : MonoBehaviour
{
    private Image accessoryImage;

    private void Start()
    {
        accessoryImage = GetComponent<Image>();

        GameObject parentCellGameObject = transform.parent.gameObject;

        Accessory accessory = parentCellGameObject.GetComponent<Accessory>();

        if (accessory != null)
        {
            // Set the accessory sprite
            SetAccessorySprite(accessory, accessory.accessorySprite);
        }
        else
        {
            Debug.LogError("No Accessory script found on the parent cell GameObject.");
        }
    }

    public void SetAccessorySprite(Accessory accessory, Sprite desiredSprite)
    {
        if (accessory != null && accessoryImage != null)
        {
            // Update the Image component to show the desired sprite
            accessoryImage.sprite = desiredSprite;
        }
    }
}
