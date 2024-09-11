using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxTimeLife = 5f;
    [SerializeField] private float power;
    [SerializeField] private float explodeRadius = 1f;
    [SerializeField] private float limitFragmentation;
    [SerializeField] private Vector2 direction;
    [SerializeField] private AudioClip fragmentEffect;
    [SerializeField] private AudioClip fragmentEndEffect;

    public float ExplodeRadius
    {
        get => explodeRadius;
        set => explodeRadius = value;
    }
    public float MaxTimeLife
    {
        get => maxTimeLife;
        set => maxTimeLife = value;
    }

    public AudioClip FragmentEffect
    {
        get => fragmentEffect;
        set => fragmentEffect = value;
    }

    public AudioClip FragmentEndEffect
    {
        get => fragmentEndEffect;
        set => fragmentEndEffect = value;
    }
    public float LimitFragmentation
    {
        get => limitFragmentation;
        set => limitFragmentation = value;
    }

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public float Power
    {
        get => power;
        set => power = value;
    }

    public Vector2 Direction
    {
        get => direction;
        set => direction = value;
    }
}
