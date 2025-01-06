using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnableBase : MonoBehaviour, ISpin
{
    public void Spin(Vector3 spinAxis, float spinSpeed)
    {
        transform.Rotate(spinAxis, spinSpeed * Time.deltaTime);
    }
}