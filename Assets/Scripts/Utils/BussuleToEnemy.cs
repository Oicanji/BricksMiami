using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BussuleToEnemy : MonoBehaviour
{
    private GameObject[] enemies;
    private Transform BussuleTransform;

    // Start is called before the first frame update
    void Start()
    {
        BussuleTransform = GameObject.Find("Bussule").transform;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Length == 0) // Verificar se há inimigos na cena
            return;

        GameObject closestEnemy = GetClosestEnemy();

        if (closestEnemy != null && closestEnemy.activeInHierarchy) // Verificar se o inimigo mais próximo existe e está ativo na hierarquia
        {
            // Aponta a rotação Z axis para o inimigo mais próximo
            BussuleTransform.rotation = Quaternion.LookRotation(Vector3.forward, closestEnemy.transform.position - transform.position);
        }
    }

    GameObject GetClosestEnemy()
    {
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject enemy in enemies)
        {
            if (enemy != null && enemy.activeInHierarchy) // Verificar se o inimigo na lista existe e está ativo na hierarquia
            {
                float distanceToEnemy = Vector3.Distance(currentPosition, enemy.transform.position);

                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = enemy;
                }
            }
        }

        return closestEnemy;
    }
}
