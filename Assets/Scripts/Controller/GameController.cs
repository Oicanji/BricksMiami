using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public int PlayerLives { get; private set; } = 3; 
    [SerializeField] float gameTimer = 120.0f; 
    [SerializeField] TextMeshProUGUI gameInfoText;

    private SceneController sceneController;

    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
        gameInfoText = FindObjectOfType<TextMeshProUGUI>();

        if (gameInfoText == null)
        {
            Debug.LogError("O objeto gameInfoText não está atribuído. Por favor, atribua-o no Inspector.");
        }

        UpdateGameInfoText();
    }

    void Update()
    {
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;

            int min = Mathf.FloorToInt(gameTimer / 60);
            int seg = Mathf.FloorToInt(gameTimer % 60);
            if (gameTimer < 0)
            {
                gameTimer = 0;
            }
            if (gameInfoText != null)
            {
                gameInfoText.text = string.Format("Tempo: {0:00}:{1:00}\nVidas: {2}", min, seg, PlayerLives);
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
        UpdateGameInfoText();
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

    void UpdateGameInfoText()
    {
        if (gameInfoText != null)
        {
            gameInfoText.text = string.Format("{0:00}:{1:00}                Vidas: {2}", Mathf.FloorToInt(gameTimer / 60), Mathf.FloorToInt(gameTimer % 60), PlayerLives);
        }
    } 
}
