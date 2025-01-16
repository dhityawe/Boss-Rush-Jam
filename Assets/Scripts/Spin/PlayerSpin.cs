using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpin : MonoBehaviour
{
    private Transform spinnable;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = worldMousePosition - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1000f, LayerMask.GetMask("Spinnable"));
            
            if (hit.collider != null)
            {
                spinnable = hit.collider.transform;
            }

            Spin();
        }
    }

    private void Spin()
    {
        if (spinnable == null)
        {
            return;
        }

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = worldMousePosition - spinnable.position;

        if (spinnable.GetComponent<ISpin>() != null)
        {
            spinnable.GetComponent<ISpin>().Spin(direction);
        }
    }
}
