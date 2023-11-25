using UnityEngine;

public class BackgroundColorChanger : MonoBehaviour
{
    public Color[] colors;
    public float duration = 5.0f; // Aumente este valor para uma transição mais lenta

    private Camera cameraComponent;
    private int colorIndex;
    private float elapsedTime;

    void Start()
    {
        cameraComponent = GetComponent<Camera>();
        colorIndex = 0;
        elapsedTime = 0.0f;
        UpdateBackgroundColor();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= duration)
        {
            elapsedTime = 0.0f;
            colorIndex = (colorIndex + 1) % colors.Length;
            UpdateBackgroundColor();
        }

        float t = elapsedTime / duration;
        int nextColorIndex = (colorIndex + 1) % colors.Length;

        cameraComponent.backgroundColor = Color.Lerp(colors[colorIndex], colors[nextColorIndex], t);
    }

    void UpdateBackgroundColor()
    {
        cameraComponent.backgroundColor = colors[colorIndex];
    }
}
