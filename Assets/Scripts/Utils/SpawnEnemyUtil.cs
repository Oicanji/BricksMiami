using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyUtil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameController>().enemies = GameObject.FindGameObjectsWithTag("Enemy");
        FindObjectOfType<GameController>().enemyCount = Mathf.Max(FindObjectOfType<GameController>().enemies.Length, 0);
    }
}
