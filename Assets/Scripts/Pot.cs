using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    public AudioClip dropSound; // Assign the drop sound effect in the Inspector

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jiggy"))
        {
            Jiggy jiggy = other.GetComponent<Jiggy>();
            if (jiggy != null)
            {
                jiggy.SetCarried(false);

                // Play the drop sound effect
                audioSource.PlayOneShot(dropSound);

                // Handle other interactions with the pot as needed
            }
        }
    }
}