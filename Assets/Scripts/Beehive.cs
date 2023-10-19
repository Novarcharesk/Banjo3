using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beehive : MonoBehaviour
{
    public GameObject honeycombPrefab; // Assign the honeycomb prefab in the Inspector
    public float forceThreshold = 10.0f; // Adjust this threshold as needed

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude < forceThreshold)
        {
            SpawnHoneycombs();
            Destroy(gameObject); // Destroy the beehive
        }
    }

    private void SpawnHoneycombs()
    {
        // Spawn honeycomb prefabs at the beehive's position
        Instantiate(honeycombPrefab, transform.position, Quaternion.identity);
        // You can spawn multiple honeycombs if needed
    }
}