using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BulletTrailManager : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector3> positions = new List<Vector3>();
    public float minDistance = 0.1f;   // Distância mínima para adicionar um novo ponto ao rastro
    public float fadeDuration = 0.1f;  // Default 0.1f

    private Vector3 lastPosition;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 0;

        AddPointToTrail(transform.position);
        lastPosition = transform.position;
    }

    public void UpdateTrail()
    {
        float distance = Vector3.Distance(lastPosition, transform.position);

        if (distance >= minDistance)
        {
            AddPointToTrail(transform.position);
            lastPosition = transform.position;
        }
    }

    private void AddPointToTrail(Vector3 newPoint)
    {
        positions.Add(newPoint);
        lineRenderer.positionCount = positions.Count;
        lineRenderer.SetPositions(positions.ToArray());
    }

    // Corrotina para aguardar o rastro desaparecer gradualmente antes de destruir a bala
    public IEnumerator WaitForTrailToFinish()
    {
        float fadeSpeed = fadeDuration / positions.Count;  // Velocidade de remoção de cada ponto

        // Loop que gradualmente remove os pontos do rastro a partir do início (ponto mais antigo)
        while (positions.Count > 0)
        {
            // Remover o ponto mais antigo da linha
            positions.RemoveAt(0);  // Remove o primeiro ponto
            lineRenderer.positionCount = positions.Count;
            lineRenderer.SetPositions(positions.ToArray());

            // Espera um curto intervalo antes de remover o próximo ponto
            yield return new WaitForSeconds(fadeSpeed);
        }
    }
}

