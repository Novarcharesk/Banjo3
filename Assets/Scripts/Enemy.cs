using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public float moveSpeed = 2.0f;
    public float playerRecoilForce = 10.0f; // Recoil force when getting close to the player
    public float moveDuration = 2.0f; // Duration for each movement step
    public float stopDuration = 1.0f; // Duration to pause between steps

    private Vector3 startPosition;
    private int currentHealth;
    private EnemySpawner spawner; // Reference to the spawner
    private Transform player; // Assign the player's transform in the Inspector
    private float timeSinceLastMove; // Timer to track movement time
    private bool isMoving; // Flag to indicate if the enemy is moving

    private InputDevice headsetDevice;

    private void Start()
    {
        startPosition = transform.position;
        currentHealth = maxHealth;

        // Find the headset device
        headsetDevice = InputDevices.GetDeviceAtXRNode(XRNode.Head);

        // Initialize the timer and movement state
        timeSinceLastMove = 0f;
        isMoving = true;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Respawn();
            return;
        }

        // Get the player's head position in VR
        Vector3 playerHeadPosition = Vector3.zero;

        if (headsetDevice != null)
        {
            headsetDevice.TryGetFeatureValue(CommonUsages.devicePosition, out playerHeadPosition);
        }

        // Determine the enemy's movement behavior
        if (isMoving)
        {
            // Continue moving towards the player
            PursuePlayer(playerHeadPosition);
            timeSinceLastMove += Time.deltaTime;

            if (timeSinceLastMove >= moveDuration)
            {
                // Stop for a second
                timeSinceLastMove = 0f;
                isMoving = false;
            }
        }
        else
        {
            // Stop for a second
            timeSinceLastMove += Time.deltaTime;

            if (timeSinceLastMove >= stopDuration)
            {
                // Resume moving
                isMoving = true;
                timeSinceLastMove = 0f;
            }
        }
    }

    private void PursuePlayer(Vector3 targetPosition)
    {
        Vector3 directionToPlayer = targetPosition - transform.position;
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

            // Apply a recoil force to the enemy in the opposite direction of the player
            Vector3 forceDirection = -collision.relativeVelocity.normalized;
            GetComponent<Rigidbody>().AddForce(forceDirection * playerRecoilForce, ForceMode.Impulse);
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