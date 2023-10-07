using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToPlayAudio : MonoBehaviour
{

    private AudioSource audioSource;

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.loop = false;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Audio clip not assigned to this component!");
        }
    }

}
