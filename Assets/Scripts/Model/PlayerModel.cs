using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private AnimationClip __meeleAttack;
    [SerializeField] private float __meeleCountdown = 10f;
    [SerializeField] private float __blinkDuration = 0.1f;
    [SerializeField] private Image __dashImage;
    [SerializeField] private AnimationClip __meleeAttack;

    public AnimationClip MeleeAttack
    {
        get => __meleeAttack;
        set => __meleeAttack = value;
    }
    public float BlinkDuration
    {
        get => __blinkDuration;
        set => __blinkDuration = value;
    }
    public Image DashImage
    {
        get => __dashImage;
        set => __dashImage = value;
    }
    public float MeeleCountdown
    {
        get => __meeleCountdown;
        set => __meeleCountdown = value;
    }
    public AnimationClip MeeleAttack
    {
        get => __meeleAttack;
        set => __meeleAttack = value;
    }
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
