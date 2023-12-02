using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    private PlayerModel __playerModel;

    [SerializeField] float gameTimer = 120.0f;
    [SerializeField] TextMeshProUGUI gameInfoText;
    [SerializeField] TextMeshProUGUI scoreText;

    private SceneController sceneController;
    private int enemyCount;
    private GameObject[] enemies; 

    private int fase;
    
    private int score = 0;
    private float scoreTimer = 2.0f;

    void Start()
    {
        __playerModel = FindObjectOfType<PlayerModel>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = Mathf.Max(enemies.Length / 2 - 1, 0);

        if (__playerModel == null)
        {
            Debug.LogError("PlayerModel não encontrado. Certifique-se de que o objeto PlayerModel está ativo na cena.");
            return;
        }
        sceneController = FindObjectOfType<SceneController>();
        gameInfoText = GameObject.Find("Temporizer").GetComponent<TextMeshProUGUI>();
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
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
            UpdateGameInfoText();
        }
        else
        {
            GameOver();
        }

        scoreTimer -= Time.deltaTime;
        if (scoreTimer <= 0)
        {
            AdicionarPontos(1); 
            scoreTimer = 2.0f; 
        }

        if ( __playerModel.Life <= 0)
        {
            GameOver();
        }
    }

    public void ReduzirVida()
    {
        if (__playerModel != null)
        {
            float vidaAtual = __playerModel.Life;

            vidaAtual--;

            __playerModel.Life = vidaAtual;
            UpdateGameInfoText();
        }
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
        PlayerPrefs.SetInt("Pontuacao", score);
        Debug.Log("Pontuação: " + score);
        PlayerPrefs.Save();
        sceneController.LoadScene("WinScene");
    }

    public void GameOver()
    {
        if (sceneController != null)
        {
            sceneController.LoadGameOver();
        }
    }

    public void InimigoMorto()
        {
            enemyCount--;
            Debug.Log("Inimigos Restantes: " + enemyCount);
            if (enemyCount <= 0)
            {
                Win();
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
            gameInfoText.text = string.Format("Tempo: {0:00}:{1:00}\nVidas: {2}", min, seg, __playerModel.Life);
        }
    }
}
