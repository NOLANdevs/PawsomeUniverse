using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI descriptionTitle;
    public TextMeshProUGUI equipButton;

    private Accessory currentAccessory = null;
    public GameObject playerHead; // ref to accessory display area

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
        // invert state
        currentAccessory.isEquipped = !currentAccessory.isEquipped;
        equipButton.text = currentAccessory.isEquipped ? "Unequip" : "Equip";

        // Handle accessory display above the player's head
        if (currentAccessory.isEquipped)
        {
            EquipAccessory();
        }
        else
        {
            UnequipAccessory();
        }
    }
}


private void EquipAccessory()
{
    if (playerHead != null && currentAccessory.accessorySprite != null)
    {
        SpriteRenderer playerHeadRenderer = playerHead.GetComponent<SpriteRenderer>();

        playerHeadRenderer.sprite = currentAccessory.accessorySprite;

        playerHead.transform.localScale = new Vector3(0.5f, 0.5f, 1f);

        // check accessory type and position correctly
        if (currentAccessory.type == Accessory.Type.Hat)
        {
            // Position for hats
            playerHead.transform.localPosition = new Vector3(0.45f, 11.6f, 0.1f);
        }
        else if (currentAccessory.type == Accessory.Type.Glasses)
        {
            // Position for glasses
            playerHead.transform.localPosition = new Vector3(0.45f, 6.34f, 0.2f); // Adjust the Z-coordinate as needed
        }
    }
}


private void UnequipAccessory()
{
    if (playerHead != null)
    {
        SpriteRenderer playerHeadRenderer = playerHead.GetComponent<SpriteRenderer>();

        playerHeadRenderer.sprite = null;
    }
}

}
