using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public static AudioManager instance;
    private bool isPaused = false;

    // scenes where pausing isnt allowed
    public List<string> notPauseScenes = new List<string>();

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySong();
    }

    // keep audio playing across scenes
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
        if (!IsCurrentSceneAllowedToPause())
        {
            // Check for the esc key press
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    // if audio is paused start playing
                    audioSource.UnPause();
                    isPaused = false;
                }
                else
                {
                    // if audio is playing then pause
                    audioSource.Pause();
                    isPaused = true;
                }
            }
        }
    }

    bool IsCurrentSceneAllowedToPause()
    {
        // check if current scene name in list of no pause scenes
        string currentSceneName = SceneManager.GetActiveScene().name;
        return !notPauseScenes.Contains(currentSceneName);
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
