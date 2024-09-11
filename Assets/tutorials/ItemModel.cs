using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModel : MonoBehaviour
{

    [SerializeField] private AudioClip __audio;

    public AudioClip Audio
    {
        get => __audio;
        set => __audio = value;
    }
}
