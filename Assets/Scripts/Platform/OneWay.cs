using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWay : MonoBehaviour
{
    private BoxCollider2D platformCollider;

    private void Awake()
    {
        platformCollider = GetComponent<BoxCollider2D>();
    }

    private IEnumerator DisablePlatformCollider()
    {
        // Optional: Disable the collider temporarily when player presses 'S' or 'Space'
        if (platformCollider != null)
        {
            platformCollider.enabled = false; // Temporarily disable platform collider
            yield return new WaitForSeconds(0.25f); // Wait for a short duration
            platformCollider.enabled = true; // Re-enable platform collider
        }
    }
}
