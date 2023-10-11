using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DescBox : MonoBehaviour
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

        playerHead.transform.localPosition = new Vector3(0.45f, 11.6f, 0.1f);
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
