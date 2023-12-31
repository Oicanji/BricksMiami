using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallModel : MonoBehaviour
{
    [SerializeField] private float __speed;
    [SerializeField] private float __maxTimeLife = 500f;
    [SerializeField] private float __power;
    [SerializeField] private float __limitFragmentation;
    [SerializeField] private Vector2 __direction;
    [SerializeField] private AudioClip __fragmentEffect;
    [SerializeField] private AudioClip __fragmentEndEffect;

    public float MaxTimeLife
    {
        get => __maxTimeLife;
        set => __maxTimeLife = value;
    }

    public AudioClip FragmentEffect
    {
        get => __fragmentEffect;
        set => __fragmentEffect = value;
    }

    public AudioClip FragmentEndEffect
    {
        get => __fragmentEndEffect;
        set => __fragmentEndEffect = value;
    }
    public float LimitFragmentation
    {
        get => __limitFragmentation;
        set => __limitFragmentation = value;
    }

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
