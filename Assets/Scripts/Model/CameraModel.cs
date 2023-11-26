using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModel : MonoBehaviour
{
    [SerializeField] private float __followSpeed = 2.0f;
    [SerializeField] private float __rotationSpeed = 0.5f;
    [SerializeField] private float __rotationMultiplier = 0.15f;

    public float FollowSpeed
    {
        get => __followSpeed;
        set => __followSpeed = value;
    }
    public float RotationSpeed
    {
        get => __rotationSpeed;
        set => __rotationSpeed = value;
    }
    public float RotationMultiplier
    {
        get => __rotationMultiplier;
        set => __rotationMultiplier = value;
    }
}
