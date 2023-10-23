using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameTag : MonoBehaviour
{
    public GameObject player;
    public GameObject playerNameTag;
    public string defaultName;
    private float horizOffset = 0;
    private float vertOffset = 2.3f;

    private TextMeshProUGUI playerName;
    private Vector3 offset;

    void Start()
    {
        playerName = playerNameTag.GetComponent<TextMeshProUGUI>();
        if (playerName.text == defaultName)
        {
            Hide();
        }
    }

    void Update()
    {
        // Track player position
        transform.position = player.transform.position + new Vector3(horizOffset, vertOffset, 0);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ChangeName(string name)
    {
        playerName.text = name;
    }
}
