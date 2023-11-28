using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private float __speed;
    [SerializeField] private float __dashSpeed;
    [SerializeField] private float __dashCooldown = 4f;
    [SerializeField] private float __life;
    [SerializeField] private float __doubleTapTimeThreshold = 0.5f; // Tempo máximo para realizar o dash
    [SerializeField] private float __invunerableTime = 10f;
    [SerializeField] private Vector2 __direction;
    [SerializeField] private AudioClip __hitEffect;
    [SerializeField] private AudioClip __invunerableEffect;

    public AudioClip InvunerableEffect
    {
        get => __invunerableEffect;
        set => __invunerableEffect = value;
    }

    public float DashCooldown
    {
        get => __dashCooldown;
        set => __dashCooldown = value;
    }

    public float DoubleTapTimeThreshold
    {
        get => __doubleTapTimeThreshold;
        set => __doubleTapTimeThreshold = value;
    }
    public float DashSpeed
    {
        get => __dashSpeed;
        set => __dashSpeed = value;
    }
    public float InvunerableTime
    {
        get => __invunerableTime;
        set => __invunerableTime = value;
    }
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
