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
        player.GetComponent<Movement>().enabled = false;
    }

    public void HideNameMenu()
    {
        inputMenu.Hide();
        player.GetComponent<Movement>().enabled = true;
    }

    public void SaveName()
    {
        playerNameText = inputName.text;
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

    public void SpawnFood()
    {
        shopMenu.SpawnFood();
    }

    public void Feed()
    {

    }
}
