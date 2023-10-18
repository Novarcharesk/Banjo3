using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text jiggyText; // Reference to the TextMeshPro Text element
    private int collectedJiggies = 0; // Variable to track the collected Jiggies

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
}