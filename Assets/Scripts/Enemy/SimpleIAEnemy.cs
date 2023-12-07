using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleIAEnemy : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 5f;
    public float detectionRadius = 5f; // Raio mínimo para detectar o jogador
    public LayerMask obstacleLayer; // Camada dos obstáculos (Wall e Breakable)
    public float obstacleDetectionDistance = 1f; // Distância para detectar obstáculos à frente

    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se o jogador está dentro do raio de detecção
        if (Vector2.Distance(transform.position, player.position) < detectionRadius)
        {
            // Calcula a direção para o jogador
            Vector2 direction = player.position - transform.position;

            // Realiza o Raycast à frente do inimigo na direção do movimento
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, obstacleDetectionDistance, obstacleLayer);

            if (hit.collider != null && hit.collider.CompareTag("Wall"))
            {
                // Se o Raycast atingir um objeto com a tag "Wall", ajusta a direção do movimento
                Vector2 newDirection = Vector2.Perpendicular(direction).normalized;
                hit = Physics2D.Raycast(transform.position, newDirection, obstacleDetectionDistance, obstacleLayer);

                if (hit.collider == null)
                {
                    // Se a nova direção não colidir com a parede, muda a direção de movimento
                    movement = newDirection;
                }
                else
                {
                    // Se a nova direção também colidir, tenta a direção oposta
                    newDirection = -newDirection;
                    hit = Physics2D.Raycast(transform.position, newDirection, obstacleDetectionDistance, obstacleLayer);

                    if (hit.collider == null)
                    {
                        // Se a direção oposta não colidir, muda a direção de movimento
                        movement = newDirection;
                    }
                    else
                    {
                        // Se ambas as direções colidirem, para de se mover
                        movement = Vector2.zero;
                    }
                }
            }
            else
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rb.rotation = angle;
                movement = direction.normalized;
            }
        }
        else
        {
            // Se o jogador estiver fora do raio de detecção, não se move
            movement = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
