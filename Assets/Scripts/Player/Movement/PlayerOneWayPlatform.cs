using System.Collections;
using UnityEngine;

public class PlayerOneWayPlatform : MonoBehaviour
{
    private GameObject currentOneWayPlatform;

    [SerializeField] private BoxCollider2D playerCollider;
    private Coroutine DescendPlatformCoroutine;

    private void Update()
    {
        // Detect pressing the 'S' or 'Space' key to temporarily disable collision
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Space))
        {
            if (currentOneWayPlatform != null)
            {   
                if (DescendPlatformCoroutine != null)
                {
                    StopCoroutine(DescendPlatformCoroutine);
                }
                
                DescendPlatformCoroutine = StartCoroutine(DisablePlatformCollider());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // When the player enters the platform's trigger area, disable the platform's collider
        if (other.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = other.gameObject;
            BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();
            if (platformCollider != null)
            {
                // Disable the platform collider
                platformCollider.enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // When the player exits the platform's trigger area, re-enable the platform's collider
        if (other.CompareTag("OneWayPlatform"))
        {
            BoxCollider2D platformCollider = other.GetComponent<BoxCollider2D>();
            if (platformCollider != null)
            {
                // Re-enable the platform collider
                platformCollider.enabled = true;
            }
        }
    }

    private IEnumerator DisablePlatformCollider()
    {
        // Optional: Disable the collider temporarily when player presses 'S' or 'Space'
        if (currentOneWayPlatform != null)
        {
            BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();
            if (platformCollider != null)
            {
                platformCollider.enabled = false; // Temporarily disable platform collider
                yield return new WaitForSeconds(0.25f); // Wait for a short duration
                platformCollider.enabled = true; // Re-enable platform collider
            }
        }
    }
}
