using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameMenu : MonoBehaviour
{
    private Button okBtn;
    private Button cancelBtn;
    private TextMeshProUGUI title;
    private TMP_InputField inputName;

    public void Awake()
    {
        okBtn = transform.Find("OkBtn").GetComponent<Button>();
        cancelBtn = transform.Find("CancelBtn").GetComponent<Button>();
        title = transform.Find("TitleText").GetComponent<TextMeshProUGUI>();
        inputName = transform.Find("InputName").GetComponent<TMP_InputField>();

        Hide();
    }

    public void Show(string titleString, string inputString, int characterLimit)
    {
        gameObject.SetActive(true);
        title.text = titleString;
        inputName.text = inputString;
        inputName.characterLimit = characterLimit;

    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
