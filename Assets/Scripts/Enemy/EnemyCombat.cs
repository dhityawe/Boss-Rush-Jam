using UnityEngine;

public class EnemyCombat : MonoBehaviour, IDamageable
{
    [SerializeField] private int health = 10; // Enemy's health

    private PlayerAbility playerAbility; // Reference to PlayerAbility for ability gauge

    void Start()
    {
        playerAbility = FindObjectOfType<PlayerAbility>(); // Find the PlayerAbility component in the scene
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        // If the enemy's health is zero or below, destroy the enemy
        if (health <= 0)
        {
            //! play enemy dead animation here
        }

        // Notify PlayerAbility to fill the ability gauge when the enemy is hit
        if (playerAbility != null)
        {
            playerAbility.FillAbilityGauge();
        }
    }
    
}
