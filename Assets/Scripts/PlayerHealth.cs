using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health
    private int currentHealth; // Current health

    public GameObject gameOverUI; // Reference to the GameOver UI object

    void Start()
    {
        currentHealth = maxHealth;
        gameOverUI.SetActive(false); // Ensure the GameOver UI is initially inactive
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
        // In this basic example, we'll just activate the GameOver UI and freeze the game.

        // Activate the GameOver UI
        gameOverUI.SetActive(true);

        // Freeze the game by stopping time
        Time.timeScale = 0f;
    }
}