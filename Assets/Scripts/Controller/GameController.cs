using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public int PlayerLives { get; private set; } = 3;
    [SerializeField] float gameTimer = 120.0f;
    [SerializeField] TextMeshProUGUI gameInfoText;
    [SerializeField] TextMeshProUGUI scoreText;

    private SceneController sceneController;
    private int score = 0;
    private float scoreTimer = 2.0f;

    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
        gameInfoText = GameObject.Find("UI").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("Points").GetComponent<TextMeshProUGUI>();

        if (gameInfoText == null || scoreText == null)
        {
            Debug.LogError("Os objetos gameInfoText e/ou scoreText não estão atribuídos. Por favor, atribua-os no Inspector.");
        }

        UpdateGameInfoText();
        UpdateScoreText();
    }

    void Update()
    {
        // Atualizar o temporizador do jogo
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
            UpdateGameInfoText();
        }
        else
        {
            GameOver();
        }

        // Atualizar o temporizador do score
        scoreTimer -= Time.deltaTime;
        if (scoreTimer <= 0)
        {
            AdicionarPontos(1); // Adiciona 1 ponto a cada 2 segundos
            scoreTimer = 2.0f; // Reinicia o temporizador
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

    void AdicionarPontos(int pontos)
    {
        score += pontos;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Pontos: " + score;
        }
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
            int min = Mathf.FloorToInt(gameTimer / 60);
            int seg = Mathf.FloorToInt(gameTimer % 60);
            if (gameTimer < 0)
            {
                gameTimer = 0;
            }
            gameInfoText.text = string.Format("Tempo: {0:00}:{1:00}\nVidas: {2}", min, seg, PlayerLives);
        }
    }
}
