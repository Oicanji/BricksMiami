using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingUtil : MonoBehaviour
{
    public float blinkInterval = 1.0f;  // Intervalo de piscar em segundos
    public float fadeDuration = 0.5f;    // Duração da transição de opacidade

    private float lastToggleTime;
    private Image titleImage;
    private Renderer titleRenderer; // Adicionando um componente Renderer
    private bool isFading = false;
    private float fadeStartTime;

    void Start()
    {
        lastToggleTime = Time.time;
        titleImage = GetComponent<Image>();
        titleRenderer = GetComponent<Renderer>(); // Tentativa de obter um componente Renderer

        if (titleImage == null && titleRenderer == null)
        {
            Debug.LogError("O componente Image ou Renderer não foi encontrado. Certifique-se de que este script está no mesmo objeto que um componente Image ou Renderer.");
        }
    }

    void Update()
    {
        // Verifique se o componente Image ou Renderer não é nulo antes de iniciar a rotina de fade
        if ((titleImage != null || titleRenderer != null) && Time.time - lastToggleTime > blinkInterval && !isFading)
        {
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

            // Atualiza a opacidade do Image ou Renderer, dependendo do que estiver presente
            if (titleImage != null)
            {
                Color newColor = titleImage.color;
                newColor.a = alpha;
                titleImage.color = newColor;
            }
            else if (titleRenderer != null)
            {
                Color newColor = titleRenderer.material.color;
                newColor.a = alpha;
                titleRenderer.material.color = newColor;
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Garante que a opacidade seja 0 ao final da transição
        if (titleImage != null)
        {
            Color finalColor = titleImage.color;
            finalColor.a = 0f;
            titleImage.color = finalColor;
        }
        else if (titleRenderer != null)
        {
            Color finalColor = titleRenderer.material.color;
            finalColor.a = 0f;
            titleRenderer.material.color = finalColor;
        }

        // Aguarda por um pequeno intervalo antes de inverter a transição
        yield return new WaitForSeconds(0.1f);

        // Inverte a transição de opacidade
        elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);

            // Atualiza a opacidade do Image ou Renderer, dependendo do que estiver presente
            if (titleImage != null)
            {
                Color newColor = titleImage.color;
                newColor.a = alpha;
                titleImage.color = newColor;
            }
            else if (titleRenderer != null)
            {
                Color newColor = titleRenderer.material.color;
                newColor.a = alpha;
                titleRenderer.material.color = newColor;
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Garante que a opacidade seja 1 ao final da transição
        if (titleImage != null)
        {
            Color finalOpaqueColor = titleImage.color;
            finalOpaqueColor.a = 1f;
            titleImage.color = finalOpaqueColor;
        }
        else if (titleRenderer != null)
        {
            Color finalOpaqueColor = titleRenderer.material.color;
            finalOpaqueColor.a = 1f;
            titleRenderer.material.color = finalOpaqueColor;
        }

        isFading = false;
    }
}
