using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccessoryManager : MonoBehaviour
{
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI descriptionTitle;
    public TextMeshProUGUI equipButton;

    private Accessory currentAccessory = null;
    private Accessory prevAccessory = null;
    public GameObject playerHead; // Reference to accessory display area

    public void ShowDescription(Accessory accessory)
    {
        currentAccessory = accessory;

        descriptionText.text = accessory.description;
        descriptionTitle.text = accessory.title;
        equipButton.text = accessory.isEquipped ? "Unequip" : "Equip";
    }

    public void ToggleEquip()
    {
        if (currentAccessory != null && currentAccessory.accessorySprite != null)
        {
            // If a different accessory is equipped, unequip the previous accessory
            if (currentAccessory != prevAccessory)
            {
                UnequipAccessory(prevAccessory);
            }

            // Invert the state of the current accessory
            currentAccessory.isEquipped = !currentAccessory.isEquipped;
            equipButton.text = currentAccessory.isEquipped ? "Unequip" : "Equip";

            // Handle the new accessory
            if (currentAccessory.isEquipped)
            {
                EquipAccessory(currentAccessory);
            }

            // Update the previous accessory to the current one
            prevAccessory = currentAccessory;
        }
    }

    private void EquipAccessory(Accessory accessory)
    {
        if (playerHead != null && accessory.accessorySprite != null)
        {
            SpriteRenderer playerHeadRenderer = playerHead.GetComponent<SpriteRenderer();

            playerHeadRenderer.sprite = accessory.accessorySprite;

            playerHead.transform.localScale = new Vector3(0.5f, 0.5f, 1f);

            // Check accessory type and position correctly
            if (accessory.type == Accessory.Type.Hat)
            {
                // Position for hats
                playerHead.transform.localPosition = new Vector3(0.45f, 11.6f, 0.1f);
            }
            else if (accessory.type == Accessory.Type.TallHat)
            {
                // Position for tall hats
                playerHead.transform.localPosition = new Vector3(0.45f, 14.1f, 0.1f);
            }
            else if (accessory.type == Accessory.Type.Glasses)
            {
                // Position for glasses
                playerHead.transform.localPosition = new Vector3(0.45f, 6.34f, 0.2f);
            }
        }
    }

    private void UnequipAccessory(Accessory accessory)
    {
        if (playerHead != null && accessory != null)
        {
            SpriteRenderer playerHeadRenderer = playerHead.GetComponent<SpriteRenderer();

            playerHeadRenderer.sprite = null;
        }
    }
}
