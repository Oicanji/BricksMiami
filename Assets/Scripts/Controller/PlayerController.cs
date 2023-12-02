using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerModel __playerModel;
    private CameraModel __cameraModel;
    private bool __verticalPressed = false;
    private bool __horizontalPressed = false;
    private float __lastTapTime = 0f;
    private GameController gameController;
    public SpriteRenderer __playerSpriteRenderer;
    private Transform __transformCharacter;
    private Transform __transform;
    private float __invunerableTime = 0f;
    private float __dashCooldown = 0f;
    private float blinkDuration = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        __playerModel = GetComponent<PlayerModel>();
        __transform = GetComponent<Transform>();
        __playerSpriteRenderer = __transform.GetChild(0).GetComponent<SpriteRenderer>();
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

        horizontalPressed();
        verticalPressed();
    }

    void horizontalPressed()
    {
        if (
            Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown(KeyCode.D)
        )
        {
            if (!__horizontalPressed) // Se não estava pressionada antes
            {
                __horizontalPressed = true;
                if (Time.time - __lastTapTime <= __playerModel.DoubleTapTimeThreshold)
                {
                    __invunerableTime = Time.time;
                    StartCoroutine(SpriteBlink(0.3f));
                    dash(Input.GetAxisRaw("Horizontal"), 0);
                }
                __lastTapTime = Time.time;
            }
            else
            {
                __horizontalPressed = false;
            }
        }
    }

    void verticalPressed()
    {
        if (
            Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.S)
        )
        {
            if (!__verticalPressed) // Se não estava pressionada antes
            {
                __verticalPressed = true;
                if (Time.time - __lastTapTime <= __playerModel.DoubleTapTimeThreshold)
                {
                    dash(0, Input.GetAxisRaw("Vertical"));
                }
                __lastTapTime = Time.time;
            }
            else
            {
                __verticalPressed = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Time.time - __invunerableTime < __playerModel.InvunerableTime)
        {
            return;
        }

        if (other.CompareTag("Enemy") ||
            other.CompareTag("Bullet")
        )
        {
            if (__playerModel.HitEffect != null)
                AudioSource.PlayClipAtPoint(__playerModel.HitEffect, transform.position);
            HandleEnemyCollision();
            __invunerableTime = Time.time;

            //Create animation fade in and fade out in SpriteRender in  __playerModel.InvunerableTime time
            StartCoroutine(SpriteBlink());
        }
    }

    IEnumerator SpriteBlink(float duration_porcent = 1f)
    {
        float timer = 0f;

        while (timer < __playerModel.InvunerableTime * duration_porcent)
        {
            __playerSpriteRenderer.enabled = !__playerSpriteRenderer.enabled;
            yield return new WaitForSeconds(blinkDuration);
            timer += blinkDuration;
        }

        __playerSpriteRenderer.enabled = true;
    }

    void HandleEnemyCollision()
    {
        if (gameController != null)
        {
            if (__playerModel.Life > 0)
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

    public void dash(float h, float w)
    {
        if (__playerModel.DashCooldown < Time.time)
        {
            __invunerableTime = Time.time;
            StartCoroutine(SpriteBlink(0.3f));
            if (__playerModel.InvunerableEffect != null)
                AudioSource.PlayClipAtPoint(__playerModel.InvunerableEffect, transform.position);

            __transform.Translate(new Vector2(__horizontalPressed ? h * __playerModel.DashSpeed : h, __verticalPressed ? w * __playerModel.DashSpeed : w) * __playerModel.Speed * Time.deltaTime);
            __dashCooldown = Time.time + __playerModel.DashCooldown;
        }
    }
}
