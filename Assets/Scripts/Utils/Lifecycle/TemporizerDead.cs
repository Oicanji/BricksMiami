using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporizerDead : MonoBehaviour
{
    [SerializeField, Tooltip("Tempo de vida total do objeto // Sicronizar com a animação")] public float lifeTime = 1.0f;

    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;
        float t = elapsedTime / lifeTime;

        if (t >= 1.0f)
        {
            Destroy(gameObject);
        }
    }
}