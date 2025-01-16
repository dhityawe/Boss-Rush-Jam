using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int health = 4; // Player's health

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            HandleDeath();
        }
    }

    private void HandleDeath()
    {
        // Add death logic here (e.g., game over screen, respawn, etc.)
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Check if the player collides with an enemy
        if (other.CompareTag("Enemy")) {
            // Apply 1 damage to the player
            TakeDamage(1);
        }
    }
}
