using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jiggy : MonoBehaviour
{
    public int points = 1; // Points to be awarded when Jiggy is dropped in the pot
    private bool isBeingCarried = false;

    private GameManager gameManager; // Reference to the GameManager

    private void Start()
    {
        // Find the GameManager in the scene and assign it to gameManager
        gameManager = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isBeingCarried && other.CompareTag("Pot"))
        {
            gameManager.AddPoints(points); // Call the AddPoints method in the GameManager
            Destroy(gameObject);
        }
    }

    public void SetCarried(bool carried)
    {
        isBeingCarried = carried;
    }
}