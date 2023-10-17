using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // You can edit this in the Inspector
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0; // Ensure health doesn't go below 0
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Ensure health doesn't exceed the maximum
        }
    }

    void Die()
    {
        // This is where you can add code to handle player death, like respawning or game over logic.
        // For example, you can reload the current scene or display a game over screen.
        // In this basic example, we'll just destroy the player GameObject.
        Destroy(gameObject);
    }
}