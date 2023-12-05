using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSceneController : MonoBehaviour
{
    void Start()
    {
        int points = PlayerPrefs.GetInt("points", 0);
        Debug.Log("Pontuação TESTE: " + points);
    }

    void Update()
    {

    }
}
