using System.Collections;
using UnityEngine;

public class PlayerOneWayPlatform : MonoBehaviour
{
    private GameObject currentOneWayPlatform;

    [SerializeField] private BoxCollider2D playerCollider;

    private void Update()
    {
        // Detect pressing the 'S' or 'Space' key to temporarily disable collision
        if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.Space))
        {
            if (currentOneWayPlatform != null)
            {   
                DisablePlatformCollider();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // When the player enters the platform's trigger area, disable the platform's collider
        if (other.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = other.gameObject;
            // BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();
            // if (platformCollider != null)
            // {
            //     // Disable the platform collider
            //     platformCollider.enabled = false;
            // }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // When the player exits the platform's trigger area, re-enable the platform's collider
        if (other.gameObject.CompareTag("OneWayPlatform"))
        {
            if (other.gameObject != currentOneWayPlatform)
            {
                return;
            }

            BoxCollider2D platformCollider = other.gameObject.GetComponent<BoxCollider2D>();
            if (platformCollider != null)
            {
                // Re-enable the platform collider
                platformCollider.isTrigger = false;
            }

            currentOneWayPlatform = null;
        }
    }

    private void DisablePlatformCollider()
    {
        // Optional: Disable the collider temporarily when player presses 'S' or 'Space'
        if (currentOneWayPlatform != null)
        {
            BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();
            if (platformCollider != null)
            {
                platformCollider.isTrigger = true; // Set platform collider to trigger
                // yield return new WaitForSeconds(0.25f); // Wait for a short duration
                // platformCollider.enabled = true; // Re-enable platform collider
            }
        }
    }
}
