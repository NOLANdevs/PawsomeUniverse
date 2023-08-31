using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameTag : MonoBehaviour
{
    public GameObject player;
    private TextMeshProUGUI playerName;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0.0f, 1.2f, 0.0f);
        playerName = transform.Find("PlayerName").GetComponent<TextMeshProUGUI>();
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
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
