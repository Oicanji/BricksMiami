using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickModel : MonoBehaviour
{
    [SerializeField] private float __life;
    [SerializeField] private AudioClip __breakEffect;
    [SerializeField] private AudioClip __hitEffect;
    [SerializeField] private float __Evasion = 0.0f;

    public float Life
    {
        get => __life;
        set => __life = value;
    }
    public AudioClip BreakEffect
    {
        get => __breakEffect;
        set => __breakEffect = value;
    }
    public AudioClip HitEffect
    {
        get => __hitEffect;
        set => __hitEffect = value;
    }

    public float Evasion
    {
        get => __Evasion;
        set => __Evasion = value;
    }
}
