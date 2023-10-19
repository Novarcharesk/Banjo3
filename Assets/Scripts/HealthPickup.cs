using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 20; // Health amount to restore
    public AudioClip pickupSound; // Assign the pickup sound effect in the Inspector

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the collider is the player
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healthAmount); // Restore the player's health

                // Play the pickup sound effect
                audioSource.PlayOneShot(pickupSound);

                Destroy(gameObject); // Remove the HealthPickup object
            }
        }
    }
}