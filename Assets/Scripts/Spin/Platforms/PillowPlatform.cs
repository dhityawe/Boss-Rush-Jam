using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PillowPlatform : SpinnableBase
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool isPlayerTouching;
    private bool isDisappearing;

    private void Update()
    {
        if (platformCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && !isPlayerTouching)
        {
            List<ContactPoint2D> contact = new List<ContactPoint2D>();
            platformCollider.GetContacts(contact);

            foreach (var point in contact)
            {
                if (point.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    if (point.normal.y < 0f)
                    {
                        isPlayerTouching = true;
                        return;
                    }
                }
            }
        }

        if (isPlayerTouching && !isDisappearing)
        {
            isDisappearing = true;
            StartCoroutine(Disappear());
        }
    }

    private IEnumerator Disappear()
    {
        float time = 0;
        while (time < 1)
        {
            time += Time.deltaTime;
            spriteRenderer.color = new Color(1, 1, 1, 1 - time);
            yield return null;
        }

        platformCollider.enabled = false;
        
        yield return new WaitForSeconds(3f);

        time = 0;
        while (time < 1f)
        {
            time += Time.deltaTime * 2;
            spriteRenderer.color = new Color(1, 1, 1, time);
            yield return null;
        }

        platformCollider.enabled = true;
        isPlayerTouching = false;
        isDisappearing = false;
    }
}
