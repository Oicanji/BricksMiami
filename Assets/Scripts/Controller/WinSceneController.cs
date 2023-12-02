using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSceneController : MonoBehaviour
{
    void Start()
    {
        int pontuacao = PlayerPrefs.GetInt("Pontuacao", 0);
        Debug.Log("Pontuação TESTE: " + pontuacao);
    }

    void Update()
    {
        
    }
}
