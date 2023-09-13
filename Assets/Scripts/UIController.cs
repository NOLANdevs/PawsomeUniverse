using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private NameMenu inputMenu;
    [SerializeField] private ShopMenu shopMenu;
    [SerializeField] private NameTag nameTag;
    public GameObject player;
    public TMP_InputField inputName;

    [SerializeField] private string playerNameText = "";

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ShowNameMenu();
        }
    }

    public void ShowNameMenu()
    {
        inputMenu.Show("Enter your pet's name:", playerNameText, 20);
        // Disable movement while typing
        player.GetComponent<Movement>().enabled = false;
    }

    public void HideNameMenu()
    {
        inputMenu.Hide();
        // Enable movement when exited
        player.GetComponent<Movement>().enabled = true;
    }

    public void SaveName()
    {
        // Save name as string in scene
        playerNameText = inputName.text;
        // Ensure current name displays when clicking on input field
        inputName.placeholder.GetComponent<TextMeshProUGUI>().text = playerNameText;
        DisplayName(playerNameText);
        inputMenu.Hide();
        player.GetComponent<Movement>().enabled = true;
    }

    public void DisplayName(string name)
    {
        nameTag.Show();
        nameTag.ChangeName(name);
    }

    public void SpawnItem()
    {
        shopMenu.SpawnItem();
    }

    public void Feed()
    {

    }
}
