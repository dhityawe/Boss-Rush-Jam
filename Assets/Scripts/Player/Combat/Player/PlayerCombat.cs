using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Camera mainCam;

    private PlayerAbility playerAbility;

    void Start()
    {
        mainCam = Camera.main;
        playerAbility = GetComponent<PlayerAbility>(); // Ensure the PlayerAbility component is attached to the player
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
}
