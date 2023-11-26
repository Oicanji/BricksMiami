using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public float velocidade = 1.0f;
    private Vector3 posicaoInicial;
    private float comprimentoTextura;
    private float suavidade = 0.1f; // Ajuste conforme necessário

    void Start()
    {
        posicaoInicial = transform.position;
        comprimentoTextura = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float deslocamento = Mathf.Repeat(Time.time * velocidade, comprimentoTextura);

        Vector3 posicaoAtual = posicaoInicial + Vector3.right * deslocamento;

        transform.position = posicaoAtual;

        if (deslocamento > comprimentoTextura * 0.5f)
        {
            CriarClone(posicaoAtual);
        }
    }

    void CriarClone(Vector3 posicaoAtual)
    {
        GameObject clone = Instantiate(gameObject);
        float novaPosicaoX = transform.position.x + comprimentoTextura - suavidade;

        clone.transform.position = new Vector3(novaPosicaoX, posicaoAtual.y, posicaoAtual.z);

        // Destroi o GameObject inteiro, incluindo todos os componentes
        Destroy(clone);
    }
}
