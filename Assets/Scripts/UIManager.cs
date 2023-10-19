using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text jiggyText; // Reference to the TextMeshPro Text element for Jiggies
    public TMP_Text healthText; // Reference to the TextMeshPro Text element for Health

    private int collectedJiggies = 0; // Variable to track the collected Jiggies
    private int playerHealth = 100; // Variable to track the player's health

    public GameManager gameManager; // Reference to the GameManager

    // Update the UI Text with the collected Jiggies count
    private void UpdateJiggyUI()
    {
        if (jiggyText != null)
        {
            jiggyText.text = "Jiggies: " + collectedJiggies.ToString(); // Update the UI Text for Jiggies
        }
    }

    // Update the UI Text with the player's health count
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + playerHealth.ToString(); // Update the UI Text for Health
        }
    }

    // Method to collect a Jiggy and update the UI
    public void CollectJiggy()
    {
        collectedJiggies++; // Increment the collected Jiggies count
        UpdateJiggyUI();

        // Add points to the player's score through the GameManager
        gameManager.AddPoints(1); // Adjust the number of points as needed
    }

    // Method to update the player's health count in the UI
    public void UpdatePlayerHealth(int newHealth)
    {
        playerHealth = newHealth; // Update the player's health count
        UpdateHealthUI();
    }
}