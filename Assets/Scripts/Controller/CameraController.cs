using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float followSpeed = 2.0f;
    public Vector3 offset;

    private Transform target;
    private float rotationSpeed = 5.0f;

    void Start()
    {
        // Encontrar o primeiro objeto com a tag "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
            // Definir a posição inicial da câmera com base no offset
            transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
        }
        else
        {
            Debug.LogWarning("Nenhum objeto com a tag 'Player' encontrado.");
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            // Calcular a posição desejada da câmera (sem seguir o eixo Z do jogador)
            Vector3 targetPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);

            // Interpolar suavemente entre a posição atual da câmera e a posição desejada
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
        // fazer a camera ficar balançando de -14g a 14g

        transform.Rotate(0, 0, Mathf.Sin(Time.time * rotationSpeed) * 0.15f);
    }
}
