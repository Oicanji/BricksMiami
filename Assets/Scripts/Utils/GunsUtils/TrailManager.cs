using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailManager : MonoBehaviour
{
    public GameObject trailPointPrefab;
    public float trailSpacing = 0.1f; // Espaçamento entre os pontos do trajeto

    private float lastTrailTime;

    public void UpdateTrail()
    {
        if (Time.time - lastTrailTime >= trailSpacing && trailPointPrefab != null)
        {
            AddTrailPoint();
            lastTrailTime = Time.time;
        }
    }

    private void AddTrailPoint()
    {
        // Criar o ponto de rastro na posição da bala e com a mesma rotação
        GameObject trailPoint = Instantiate(trailPointPrefab, transform.position, transform.rotation);
        trailPoint.transform.rotation = transform.rotation; // Alinhar a rotação do ponto de rastro com a bala
    }
}
