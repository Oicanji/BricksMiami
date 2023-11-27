using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemyUI : MonoBehaviour
{
    public string playerTag = "Player";
    public string enemyTag = "Enemy";
    public float rotationSpeed = 5.0f;

    private GameObject player;
    private GameObject[] enemies;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);
    }

    private void Update()
    {
        if (player == null || enemies.Length == 0)
        {
            Debug.LogWarning("Player or Enemies not found");
            return;
        }

        GameObject closestEnemy = FindClosestEnemy();
        if (closestEnemy != null)
        {
            Vector3 direction = closestEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private GameObject FindClosestEnemy()
    {
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
}