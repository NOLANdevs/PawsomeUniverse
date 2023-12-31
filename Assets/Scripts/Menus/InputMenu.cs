using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputMenu : MonoBehaviour
{
    public TMP_InputField inputName;

    [SerializeField] private NameMenu inputMenu;
    [SerializeField] private NameTag nameTag;
    [SerializeField] private string playerNameText = "";

    void Start()
    {
    }

    void Update()
    {
        // Open pet name menu on N keypress
        if (!GameLogic.isPaused && Input.GetKeyDown(KeyCode.N))
        {
            ShowNameMenu();
            GameLogic.PauseGame();
        }
    }

    public void ShowNameMenu()
    {
        inputMenu.Show("Enter your pet's name:", playerNameText, 20);
    }

    public void HideNameMenu()
    {
        GameLogic.UnpauseGame();
        inputMenu.Hide();
    }

    public void SaveName()
    {
        // Save name as string in scene
        playerNameText = inputName.text;
        // Ensure current name displays when clicking on input field
        inputName.placeholder.GetComponent<TextMeshProUGUI>().text = playerNameText;
        GameLogic.activeAnimal.animalName = playerNameText;
        DisplayName(playerNameText);
        HideNameMenu();
    }

    public void DisplayName(string name)
    {
        nameTag.Show();
        nameTag.ChangeName(name);
    }
}
