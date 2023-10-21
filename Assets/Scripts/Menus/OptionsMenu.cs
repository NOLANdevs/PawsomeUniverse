using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    [SerializeField] private TextMeshProUGUI volumeText;

    public AudioMixer audioMixer;

    public void Start()
    {
        // Update slider text
        //volumeSlider.onValueChanged.AddListener((v) => volumeText.text = (v).ToString("0%"));
        float volume = volumeSlider.value;
        float convertVolume = volume / 80 + 1;
        volumeText.text = (convertVolume.ToString("0%"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setVolume(float volume)
    {
        float convertVolume = volume / 80 + 1;
        volumeText.text = (convertVolume.ToString("0%"));
        audioMixer.SetFloat("volume", volume);
    }
}
