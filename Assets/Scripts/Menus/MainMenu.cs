using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    [SerializeField] private TextMeshProUGUI volumeText;

    public void Start()
    {
        volumeSlider.onValueChanged.AddListener((v) => volumeText.text = (v).ToString("0%"));
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    { 
        Debug.Log("Quit");
        Application.Quit();
    }


}
