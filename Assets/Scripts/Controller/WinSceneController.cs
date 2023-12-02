using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinSceneController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    
    void Start()
    {
        int pontuacao = PlayerPrefs.GetInt("Pontuacao", 0);
        Debug.Log("Pontuação TESTE: " + pontuacao);
        scoreText = GameObject.Find("Points").GetComponent<TextMeshProUGUI>();
        scoreText.text = "Pontos: " + pontuacao;

    }

    void Update()
    {
        
    }
}
