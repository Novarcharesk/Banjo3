using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardController : MonoBehaviour
{
    public GameObject collectiblePrefab; // Reference to the collectible prefab

    public void SpawnReward(Vector3 spawnPosition)
    {
        Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
    }
}