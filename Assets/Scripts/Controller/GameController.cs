using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public int PlayerLives { get; private set; } = 3; 
    [SerializeField] float gameTimer = 120.0f; 
    [SerializeField] TextMeshProUGUI timerText;

    private SceneController sceneController;

    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
        timerText = FindObjectOfType<TextMeshProUGUI>();

        if (timerText == null)
        {
            Debug.LogError("O objeto timerText não está atribuído. Por favor, atribua-o no Inspector.");
        }
    }

    void Update()
    {
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;

            int min = Mathf.FloorToInt(gameTimer / 60);
            int seg = Mathf.FloorToInt(gameTimer % 60);

            if (timerText != null)
            {
                timerText.text = string.Format("{0:00}:{1:00}", min, seg);
            }
        }
        else
        {
            GameOver(); 
        }

        if (PlayerLives <= 0)
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
        if (sceneController != null)
        {
            sceneController.CarregarCenaGameOver();
        }
    }
}
