using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool; // Reference to the bullet pool
    [SerializeField] private Transform firePoint;   // Position where bullets are spawned
    [SerializeField] private float shootInterval = 0.2f; // Time between shots

    private float shootTimer; // Timer to track shooting intervals
    private bool isShooting; // Flag to check if the player is holding the shoot button

    void Update()
    {
        HandleShootingInput();
    }

    private void HandleShootingInput()
    {
        if (Input.GetMouseButton(0)) // Hold left mouse button to shoot
        {
            isShooting = true;
            ShootWithInterval();
        }
        else
        {
            isShooting = false;
        }
    }

    private void ShootWithInterval()
    {
        if (!isShooting) return;

        // Increment the shoot timer by the time elapsed since the last frame
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval) // Check if the interval has passed
        {
            Fire(); // Spawn a bullet
            shootTimer = 0f; // Reset the timer
        }
    }

    private void Fire()
    {
        GameObject bullet = bulletPool.GetBullet(firePoint.position, firePoint.rotation);
        if (bullet != null)
        {
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = firePoint.right * 10f; // Set bullet velocity (adjust speed as needed)
            }
        }
    }
}
