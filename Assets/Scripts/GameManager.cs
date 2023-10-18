using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text inventoryText;  // Assign the UI Text element to display the inventory

    private Dictionary<string, int> inventory = new Dictionary<string, int>();

    // Add an item to the inventory
    public void AddItem(string itemName)
    {
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName]++;
        }
        else
        {
            inventory[itemName] = 1;
        }

        UpdateInventoryUI();
    }

    // Remove an item from the inventory
    public void RemoveItem(string itemName)
    {
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName]--;

            if (inventory[itemName] <= 0)
            {
                inventory.Remove(itemName);
            }

            UpdateInventoryUI();
        }
    }

    // Update the inventory UI text
    private void UpdateInventoryUI()
    {
        string inventoryInfo = "Inventory:\n";

        foreach (var item in inventory)
        {
            inventoryInfo += $"{item.Key}: {item.Value}\n";
        }

        inventoryText.text = inventoryInfo;
    }
}