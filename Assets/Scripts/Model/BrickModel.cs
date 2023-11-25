using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickModel : MonoBehaviour
{
    [SerializeField] private float __life;

    public float Life
    {
        get => __life;
        set => __life = value;
    }
}
