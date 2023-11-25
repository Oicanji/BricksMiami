using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolModel : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioClip shotSound;
    [SerializeField] private AudioClip reloadSound;
    [SerializeField] private float fireRate;
    [SerializeField] private int bullets;
    [SerializeField] private float reloadTime;
    [SerializeField] private float distanceSpawnY;


    public GameObject Bullet
    {
        get { return bullet; }
        set { bullet = value; }
    }
    public float FireRate
    {
        get { return fireRate; }
        set { fireRate = value; }
    }
    public int Bullets
    {
        get { return bullets; }
        set { bullets = value; }
    }
    public float ReloadTime
    {
        get { return reloadTime; }
        set { reloadTime = value; }
    }
    public float DistanceSpawnY
    {
        get { return distanceSpawnY; }
        set { distanceSpawnY = value; }
    }
    public AudioClip ShotSound
    {
        get { return shotSound; }
        set { shotSound = value; }
    }

    public AudioClip ReloadSound
    {
        get { return reloadSound; }
        set { reloadSound = value; }
    }
}
