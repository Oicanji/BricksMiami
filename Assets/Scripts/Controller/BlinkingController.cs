using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingController : MonoBehaviour
{
    public float blinkInterval = 1.0f;  // Intervalo de piscar em segundos
    public float fadeDuration = 0.5f;    // Duração da transição de opacidade

    private float lastToggleTime;
    private Renderer titleRenderer;
    private bool isFading = false;
    private float fadeStartTime;
    
    void Start()
    {
        lastToggleTime = Time.time;
        titleRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Time.time - lastToggleTime > blinkInterval && !isFading)
        {
            // Inicia a transição de opacidade
            StartCoroutine(FadeTitle());

            // Atualiza o último tempo de alternância
            lastToggleTime = Time.time;
        }
    }

    IEnumerator FadeTitle()
    {
        isFading = true;
        fadeStartTime = Time.time;

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // Calcula a opacidade com base no tempo decorrido
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            // Atualiza a opacidade do material
            Color newColor = titleRenderer.material.color;
            newColor.a = alpha;
            titleRenderer.material.color = newColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Garante que a opacidade seja 0 ao final da transição
        Color finalColor = titleRenderer.material.color;
        finalColor.a = 0f;
        titleRenderer.material.color = finalColor;

        // Aguarda por um pequeno intervalo antes de inverter a transição
        yield return new WaitForSeconds(0.1f);

        // Inverte a transição de opacidade
        elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);

            Color newColor = titleRenderer.material.color;
            newColor.a = alpha;
            titleRenderer.material.color = newColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Garante que a opacidade seja 1 ao final da transição
        Color finalOpaqueColor = titleRenderer.material.color;
        finalOpaqueColor.a = 1f;
        titleRenderer.material.color = finalOpaqueColor;

        isFading = false;
    }
}