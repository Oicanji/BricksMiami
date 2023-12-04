using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

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
    private float max_life;
    private Character character;
    public Character[] characters;
    public string name_player;
    public string name_weapon;
    private SpriteRenderer __playerSprite;
    private Image __playerName;
    private ProfileUI __playerImage;
    private Animator __playerAnimator;
    private SpriteRenderer __playerMeleeSprite;
    private AnimatorOverrideController animatorOverrideController;
    public Sprite PistolUI;
    public Sprite ShotgunUI;
    public Sprite MissileUI;
    public Sprite AKUI;
    private Image IcoGun;

    void Start()
    {
        __playerModel = FindObjectOfType<PlayerModel>();
        __playerSprite = GameObject.Find("PlayerSprite").GetComponent<SpriteRenderer>();
        __playerImage = GameObject.Find("PlayerImage").GetComponent<ProfileUI>();
        __playerName = GameObject.Find("PlayerName").GetComponent<Image>();
        __playerAnimator = GameObject.Find("MeeleSprite").GetComponent<Animator>();
        __playerMeleeSprite = GameObject.Find("MeeleSprite").GetComponent<SpriteRenderer>();
        animatorOverrideController = new AnimatorOverrideController(__playerAnimator.runtimeAnimatorController);

        IcoGun = GameObject.Find("IcoGun").GetComponent<Image>();

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = Mathf.Max(enemies.Length, 0);

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

        if (!PlayerPrefs.HasKey("characterName"))
        {
            PlayerPrefs.SetString("characterName", "player");
            PlayerPrefs.Save();
        }
        name_player = PlayerPrefs.GetString("characterName");
        if (!PlayerPrefs.HasKey("weaponName"))
        {
            PlayerPrefs.SetString("weaponName", "pistol");
            PlayerPrefs.Save();
        }
        name_weapon = PlayerPrefs.GetString("weaponName");

        foreach (Character c in characters)
        {
            if (c.id == name_player)
            {
                character = c;
                break;
            }
        }

        GameObject pistol = GameObject.Find("Pistol");
        pistol.SetActive(false);
        GameObject shotgun = GameObject.Find("Shotgun");
        shotgun.SetActive(false);
        GameObject missile = GameObject.Find("MissileGun");
        missile.SetActive(false);
        GameObject ak = GameObject.Find("AK");
        ak.SetActive(false);

        switch (name_weapon)
        {
            case "pistol":
                pistol.SetActive(true);
                IcoGun.sprite = PistolUI;
                break;
            case "shotgun":
                shotgun.SetActive(true);
                IcoGun.sprite = ShotgunUI;
                break;
            case "missile":
                missile.SetActive(true);
                IcoGun.sprite = MissileUI;
                break;
            case "ak":
                ak.SetActive(true);
                IcoGun.sprite = AKUI;
                break;
        }

        CharacterBuild();
    }

    void CharacterBuild()
    {
        __playerModel.Life = character.life;
        max_life = character.life;
        __playerModel.Speed = character.speed;
        __playerModel.DashSpeed = character.dashSpeed;
        __playerModel.DashCooldown = character.dashCooldown;
        __playerModel.DoubleTapTimeThreshold = character.doubleTapTimeThreshold;
        __playerModel.InvunerableTime = character.invunerableTime;
        __playerModel.MeeleAttack = character.meeleAttack;
        __playerModel.MeeleCountdown = character.meeleCountdown;


        __playerModel.HitEffect = character.hitEffect;
        __playerModel.InvunerableEffect = character.invunerableEffect;

        //Get Prite from Player
        __playerSprite.sprite = character.idle;

        __playerImage.ProfileMax = character.profileMax;
        __playerImage.ProfileMed = character.profileMed;
        __playerImage.ProfileMin = character.profileMin;

        __playerImage.UpdateProfile(character.life, max_life);

        __playerName.sprite = character.uiName;

        animatorOverrideController["player_melee"] = character.meeleAttack;
        animatorOverrideController["player_melee_idle"] = character.meeleAttackSprite;
        __playerAnimator.runtimeAnimatorController = animatorOverrideController;
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

        if (__playerModel.Life <= 0)
        {
            GameOver();
        }
    }

    public void ReduzirVida()
    {
        if (__playerModel != null)
        {
            __playerModel.Life--;
            __playerImage.UpdateProfile(__playerModel.Life, max_life);
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
        PlayerPrefs.Save();
        sceneController.LoadScene("win_scene");
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
            gameInfoText.text = string.Format("Tempo: {0:00}:{1:00}", min, seg);
        }
    }
}
