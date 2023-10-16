using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public float moveSpeed = 2.0f;

    private Transform player;
    private Vector3 startPosition;
    private int currentHealth;
    private EnemySpawner spawner; // Reference to the spawner

    private bool isPursuing = false;

    private void Start()
    {
        player = Camera.main.transform; // Assuming the player's camera is the main camera in your VR scene
        startPosition = transform.position;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Respawn();
            return;
        }

        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Modify the pursuit logic to suit your needs
        if (distanceToPlayer < 0.5f)
        {
            isPursuing = true;
        }
        else
        {
            isPursuing = false;
        }

        if (isPursuing)
        {
            PursuePlayer();
        }
    }

    private void PursuePlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.Normalize();
        transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
    }

    public void SetSpawner(EnemySpawner spawnerReference)
    {
        spawner = spawnerReference;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentHealth -= 10; // Adjust the damage amount
        }
    }

    private void Respawn()
    {
        // Reset the enemy's position to its initial position
        transform.position = startPosition;
        currentHealth = maxHealth;

        // Notify the spawner that this enemy is defeated
        spawner.EnemyDefeated();
    }
}