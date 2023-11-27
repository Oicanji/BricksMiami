using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private float __speed;
    [SerializeField] private float __life;
    [SerializeField] private Vector2 __direction;
    [SerializeField] private AudioClip __hitEffect;

    public float Speed
    {
        get => __speed;
        set => __speed = value;
    }

    public float Life
    {
        get => __life;
        set => __life = value;
    }

    public Vector2 Direction
    {
        get => __direction;
        set => __direction = value;
    }
    public AudioClip HitEffect
    {
        get => __hitEffect;
        set => __hitEffect = value;
    }
}
