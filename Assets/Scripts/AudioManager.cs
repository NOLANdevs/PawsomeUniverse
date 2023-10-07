using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public static AudioManager instance;
    private bool isPaused = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySong();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Check for the esc key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                // If audio is paused start playing
                audioSource.UnPause();
                isPaused = false;
            }
            else
            {
                // If audio is playing then pause
                audioSource.Pause();
                isPaused = true;
            }
        }
    }

    void PlaySong()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Audio clip not assigned to this component!");
        }
    }
}
