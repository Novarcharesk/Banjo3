using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    public Text healthText;  // Assign the UI Text element for health
    public Text scoreText;  // Assign the UI Text element for score

    private int playerHealth = 100; // Initialize the player's health
    private int playerScore = 0; // Initialize the player's score

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Set the initial UI text to display player's health and score
        healthText.text = "Health: " + playerHealth.ToString();
        scoreText.text = "Score: " + playerScore.ToString();

        // Add any other initialization code here
    }

    public void TakeDamage(int damageAmount)
    {
        playerHealth -= damageAmount;
        // Update the UI element to display the current playerHealth
        healthText.text = "Health: " + playerHealth.ToString();

        // Add any additional logic for taking damage
    }

    public void Heal(int healAmount)
    {
        playerHealth += healAmount;
        // Update the UI element to display the current playerHealth
        healthText.text = "Health: " + playerHealth.ToString();

        // Add any additional logic for healing
    }

    public void AddPoints(int pointsToAdd)
    {
        playerScore += pointsToAdd;
        // Update the UI element to display the current playerScore
        scoreText.text = "Score: " + playerScore.ToString();

        // Add any additional scoring logic
    }

    // Add any other game management functions and logic here
}