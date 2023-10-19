using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text jiggyText; // Reference to the TextMeshPro Text element
    public GameObject gameoverScreen; // Reference to the game over screen GameObject
    private int collectedJiggies = 0; // Variable to track the collected Jiggies

    // Start is called before the first frame update
    void Start()
    {
        // Hide the game over screen initially
        gameoverScreen.SetActive(false);
    }

    // Update the UI Text with the collected Jiggies count
    private void UpdateJiggyUI()
    {
        if (jiggyText != null)
        {
            jiggyText.text = "Jiggies: " + collectedJiggies.ToString(); // Update the UI Text
        }
    }

    // Method to collect a Jiggy and update the UI
    public void CollectJiggy()
    {
        collectedJiggies++; // Increment the collected Jiggies count
        UpdateJiggyUI();
    }

    // Method to display the game over screen
    public void ShowGameoverScreen()
    {
        gameoverScreen.SetActive(true);
    }

    // Method to reload the scene
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}