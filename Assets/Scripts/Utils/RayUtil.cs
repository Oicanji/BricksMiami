using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayUtil : MonoBehaviour
{
    public float tempoTotalDeVida = 5f; // Tempo total de vida do objeto em segundos
    private float tempoDecorrido = 0f;  // Tempo decorrido desde a criação do objeto
    public Vector3 reducaoDeEscala = new Vector3(0.1f, 0.1f, 0.1f); // Valor de redução de escala a cada segundo

    void Update()
    {
        // Incrementa o tempo decorrido
        tempoDecorrido += Time.deltaTime;

        // Calcula a escala atual do objeto
        Vector3 novaEscala = transform.localScale - reducaoDeEscala * Time.deltaTime;

        // Aplica a nova escala ao objeto
        transform.localScale = novaEscala;

        // Verifica se o tempo total de vida foi atingido
        if (tempoDecorrido >= tempoTotalDeVida)
        {
            // Destroi o objeto quando o tempo total de vida for atingido
            Destroy(gameObject);
        }
    }
}
