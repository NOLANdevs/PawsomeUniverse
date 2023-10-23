using UnityEngine;

public class ClickToPlayAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private bool canInteract = true; // Flag to control interactions

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (canInteract && audioSource != null && audioSource.clip != null)
        {
            audioSource.loop = false;
            audioSource.playOnAwake = false;
            audioSource.Play();
        }
    }

    public void SetInteract(bool state)
    {
        canInteract = state;
    }
}
