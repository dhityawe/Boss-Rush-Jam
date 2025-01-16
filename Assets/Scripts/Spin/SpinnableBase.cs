using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnableBase : MonoBehaviour, ISpin
{
    [SerializeField] 
    private bool isChild;
    [SerializeField]
    private List<float> possibleAngles = new List<float> { 0, 90, 180, 270, -90, -180, -270 };

    public void Spin(Vector3 spinDirection)
    {
        if (isChild)
        {
            float angle = Mathf.Atan2(spinDirection.y, spinDirection.x) * Mathf.Rad2Deg;
            float closestAngle = possibleAngles[0];
            float minDifference = Mathf.Abs(angle - possibleAngles[0]);

            print(angle);

            foreach (float possibleAngle in possibleAngles)
            {
                float difference = Mathf.Abs(angle - possibleAngle);

                if (difference < minDifference)
                {
                    minDifference = difference;
                    closestAngle = possibleAngle;
                }
            }

            transform.parent.rotation = Quaternion.Euler(0, 0, closestAngle);
        }

        else
        {
            float angle = Mathf.Atan2(spinDirection.y, spinDirection.x) * Mathf.Rad2Deg;
            float closestAngle = possibleAngles[0];
            float minDifference = Mathf.Abs(angle - possibleAngles[0]);

            foreach (float possibleAngle in possibleAngles)
            {
                float difference = Mathf.Abs(angle - possibleAngle);

                if (difference < minDifference)
                {
                    minDifference = difference;
                    closestAngle = possibleAngle;
                }
            }

            transform.rotation = Quaternion.Euler(0, 0, closestAngle);
        }
    }
}