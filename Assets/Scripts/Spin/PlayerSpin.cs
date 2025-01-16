using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpin : MonoBehaviour
{
    private Transform spinnable;

    [SerializeField]
    private int abilityBars = 3;

    [SerializeField]
    private float timeWindow = 3f;

    private bool isSpinning;

    private Coroutine abilityWindow;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EnterAbility();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ExitAbility();
        }

        if (Input.GetKey(KeyCode.Mouse0) && isSpinning)
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

    private void EnterAbility()
    {
        Time.timeScale = 0.1f;
        isSpinning = true;
        abilityWindow = StartCoroutine(AbilityWindow());
    }

    private IEnumerator AbilityWindow()
    {
        yield return new WaitForSecondsRealtime(timeWindow);

        ExitAbility();
    }

    private void ExitAbility()
    {
        if (abilityWindow != null)
        {
            StopCoroutine(abilityWindow);
        }

        isSpinning = false;

        Time.timeScale = 1f;

        spinnable = null;
    }
}
