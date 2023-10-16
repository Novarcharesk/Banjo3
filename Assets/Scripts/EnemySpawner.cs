using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints; // An array of spawn points
    public int maxEnemies = 5; // Maximum number of enemies to be spawned
    public float respawnDelay = 30.0f; // Delay for respawning enemies
    public GameObject pursuitRange; // Assign the pursuit range GameObject in the Unity Inspector

    private int currentEnemies = 0;
    private bool isRespawning = false;

    private void Update()
    {
        if (currentEnemies < maxEnemies && !isRespawning)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points assigned to the spawner.");
            return;
        }

        // Randomly select a spawn point from the array
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Spawn the enemy at the selected spawn point
        GameObject newEnemy = Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);

        // Increase the current enemy count
        currentEnemies++;

        // Attach a reference to this spawner on the enemy
        newEnemy.GetComponent<Enemy>().SetSpawner(this);
    }

    public void EnemyDefeated()
    {
        currentEnemies--;

        if (currentEnemies <= 0)
        {
            StartCoroutine(RespawnDelay());
        }
    }

    private IEnumerator RespawnDelay()
    {
        isRespawning = true;
        yield return new WaitForSeconds(respawnDelay);
        isRespawning = false;
        currentEnemies = 0;
    }
}