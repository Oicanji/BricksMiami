using UnityEngine;

public class TrailsUtil : MonoBehaviour
{
    public float shrinkDuration = 1.0f; // Duração da diminuição (em segundos)
    public float finalSize = 0.1f; // Tamanho final desejado

    private float initialSize;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
        initialSize = transform.localScale.x;
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;
        float t = Mathf.Clamp01(elapsedTime / shrinkDuration);
        float newSize = Mathf.Lerp(initialSize, finalSize, t);

        transform.localScale = new Vector3(newSize, newSize, newSize);

        if (t >= 1.0f)
        {
            Destroy(gameObject);
        }
    }
}