using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    [SerializeField]private float abilityGauge = 0f; 
    private float abilityGaugeFill = 0f; 
    private const float maxAbilityGauge = 3f; 

    public float AbilityGauge => abilityGauge; // Read-only access to the ability gauge

    [SerializeField] private PlayerCombat playerCombat; 

    void Start()
    {
        playerCombat = GetComponent<PlayerCombat>();
    }

    void Update()
    {
        if (abilityGauge >= 1f)
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                RotateAbility();
            }
        }
    }

    public void FillAbilityGauge()
    {
        // Fill the ability gauge by 0.1 for each bullet that hits an enemy
        if (abilityGauge < maxAbilityGauge)
        {
            abilityGaugeFill += 0.1f;

            // If the gauge reaches 1, reset and start filling a new gauge
            if (abilityGaugeFill >= 1f)
            {
                abilityGaugeFill = 0f;
                abilityGauge += 1f;
            }
        }
    }

    //* make new ability below
    public void RotateAbility()
    {
        abilityGauge -= 1f;
    }
}
