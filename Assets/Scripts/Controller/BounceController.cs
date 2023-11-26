using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceController : MonoBehaviour
{
    public float rotationSpeed = 2.0f;  // Reduzir a velocidade
    public float bounceAmplitude = 10.0f;  // Reduzir a amplitude

    void FixedUpdate()
    {
        float rotationValue = Mathf.Sin(Time.time * rotationSpeed) * bounceAmplitude;

        transform.rotation = Quaternion.Euler(0, 0, rotationValue);
    }
}
