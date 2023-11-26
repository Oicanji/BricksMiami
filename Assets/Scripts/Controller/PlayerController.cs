using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerModel __playerModel;
    private CameraModel __cameraModel;
    private Transform __transform;
    private Transform __transformCharacter;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        __playerModel = GetComponent<PlayerModel>();
        __transform = GetComponent<Transform>();
        __transformCharacter = __transform.GetChild(0);
        __cameraModel = Camera.main.GetComponent<CameraModel>();
        gameController = FindObjectOfType<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
        // Obter a posição do mouse na tela
        Vector3 mousePos = Input.mousePosition;
        // Converter a posição do mouse de tela para uma posição no mundo
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.z - transform.position.z));
        // Calcular a direção do mouse em relação ao jogador
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        // Normalizar o vetor de direção para obter apenas a direção sem a magnitude
        direction.Normalize();

        // Rotacionar o jogador para olhar na direção do mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        __transformCharacter.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            HandleEnemyCollision();  
        }
    }

    void HandleEnemyCollision()
    {
        if (gameController != null)
        {
            if (gameController.PlayerLives > 0)
            {
                gameController.ReduzirVida();
            }
            else
            {
                gameController.GameOver();
            }
        }
    }



    public void Move(float h, float w)
    {
        __transform.Translate(new Vector2(h, w) * __playerModel.Speed * Time.deltaTime);
    }
}
