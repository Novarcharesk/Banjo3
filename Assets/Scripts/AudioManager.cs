using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton instance

    public AudioSource musicSource; // For background music
    public AudioSource sfxSource;   // For sound effects

    private void Awake()
    {
        // Singleton pattern to ensure there's only one AudioManager instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // Keep AudioManager alive across scenes
    }

    // Play background music
    public void PlayMusic(AudioClip musicClip)
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }

        musicSource.clip = musicClip;
        musicSource.Play();
    }

    // Play a sound effect
    public void PlaySFX(AudioClip sfxClip)
    {
        sfxSource.PlayOneShot(sfxClip);
    }
}