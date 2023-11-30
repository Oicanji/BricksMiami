using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickModel : MonoBehaviour
{
    [SerializeField] private float __life;
    [SerializeField] private AudioClip __breakEffect;
    [SerializeField] private AudioClip __hitEffect;
    [SerializeField] private float __Evasion = 0.0f;
    [SerializeField] private GameObject[] __drops;
    [SerializeField] private float __dropChance = 1.0f;
    [SerializeField] private GameObject __spawnObjectOnDestroy;
    [SerializeField] private float __spawnChance = 1.0f;

    public GameObject SpawnObjectOnDestroy
    {
        get => __spawnObjectOnDestroy;
        set => __spawnObjectOnDestroy = value;
    }
    public float SpawnChance
    {
        get => __spawnChance;
        set => __spawnChance = value;
    }
    public GameObject[] Drops
    {
        get => __drops;
        set => __drops = value;
    }
    public float DropChance
    {
        get => __dropChance;
        set => __dropChance = value;
    }

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
