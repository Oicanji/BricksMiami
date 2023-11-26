using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int PlayerLives { get; private set; } = 3; 
    public float gameTimer = 120.0f; 
    public SceneController sceneController;

    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
    }

    void Update()
    {
        gameTimer -= Time.deltaTime;
        if (PlayerLives <= 0)
        {
            GameOver(); 
        }

        if (gameTimer <= 0)
        {
            GameOver(); 
        }
    }

    public void ReduzirVida()
    {
        PlayerLives--;
    }

    void Win()
    {
        // SceneManager.LoadScene("WinScene");
    }

    public void GameOver()
    {
        if (sceneController != null){
            sceneController.CarregarCenaGameOver();
        }
    }
}
