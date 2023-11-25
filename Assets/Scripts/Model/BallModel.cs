using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallModel : MonoBehaviour
{
    [SerializeField]private float __speed;
    [SerializeField]private float __power;
    [SerializeField]private Vector2 __direction;

    public float Speed
    {
        get => __speed;
        set => __speed = value;
    }

    public float Power
    {
        get => __power;
        set => __power = value;
    }

    public Vector2 Direction
    {
        get => __direction;
        set => __direction = value;
    }
}
