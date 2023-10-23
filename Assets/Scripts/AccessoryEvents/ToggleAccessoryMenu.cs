using UnityEngine;

public class ToggleAccessoryMenu : MonoBehaviour
{
    public GameObject accessoryMenu;  
    public Movement playerMovement; 
    public ToggleOnClick toggleOnClick; 
    private bool canInteract = true;

    private bool isAccessoryMenuActive = false;

    [SerializeField] private AudioSource openSound;

    private void Start()
    {
        SetAccessoryMenuActive(false);
        SetPlayerMovementActive(true); 
    }

    // if clicked, toggle menu
    private void OnMouseDown()
    {
        if (canInteract){
            openSound.Play();
            ToggleMenu();
            toggleOnClick.ToggleInteraction(false);
            changeInteraction();
        }
    }

    public void changeInteraction(){
        canInteract = !canInteract;
    }

    public void ToggleMenu()
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
