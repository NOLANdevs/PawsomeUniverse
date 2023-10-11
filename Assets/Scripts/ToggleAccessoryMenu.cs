using UnityEngine;

public class ToggleAccessoryMenu : MonoBehaviour
{
    public GameObject accessoryMenu;  
    public Movement playerMovement;  

    private bool isAccessoryMenuActive = false;

    private void Start()
    {
        SetAccessoryMenuActive(false);
        SetPlayerMovementActive(true); 
    }

    // if clicked, toggle menu
    private void OnMouseDown()
    {
        ToggleMenu();
    }

    private void ToggleMenu()
    {
        isAccessoryMenuActive = !isAccessoryMenuActive;

        SetAccessoryMenuActive(isAccessoryMenuActive);

        SetPlayerMovementActive(!isAccessoryMenuActive);
    }

    private void SetAccessoryMenuActive(bool isActive)
    {
        accessoryMenu.SetActive(isActive);
    }

    private void SetPlayerMovementActive(bool isActive)
    {
        // check if player movement script exists
        if (playerMovement != null)
        {
            // enable or disable player's movement script
            playerMovement.enabled = isActive;
        }
    }
}
