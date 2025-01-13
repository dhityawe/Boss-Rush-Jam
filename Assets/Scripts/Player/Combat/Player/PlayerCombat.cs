using UnityEngine;

public class PlayerCombat : MonoBehaviour, IDamageable
{
    [SerializeField] private int health = 4; // Player's health
    private Camera mainCam;

    private PlayerAbility playerAbility;
    [SerializeField]private Collider2D playerCollider; // Reference to the player's collider in the parent

    void Start()
    {
        mainCam = Camera.main;
        playerAbility = GetComponent<PlayerAbility>(); // Ensure the PlayerAbility component is attached to the player
        playerCollider = GetComponentInParent<Collider2D>(); // Get the collider from the parent object
    }

    void Update()
    {
        Aiming();
    }

    private void Aiming()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log($"Player took {amount} damage! Remaining health: {health}");

        if (health <= 0)
        {
            HandleDeath();
        }
    }

    private void HandleDeath()
    {
        Debug.Log("Player is dead!");
        // Add death logic here (e.g., game over screen, respawn, etc.)
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with enemy!");
            TakeDamage(1); // Damage amount for enemy collision
        }
    }
}
