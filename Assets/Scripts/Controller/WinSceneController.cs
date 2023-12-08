using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinSceneController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    
    void Start()
    {
        int points = PlayerPrefs.GetInt("points", 0);
        Debug.Log("Pontuação TESTE: " + points);
    }

    void Update()
    {

    }
}
