using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public BallModel __ballModel;
    private Rigidbody2D __rigidbodyBall;
    private Vector2 __mouseDirection;
    // Start is called before the first frame update
    void Start()
    {
        __ballModel = GetComponent<BallModel>();
        __rigidbodyBall = GetComponent<Rigidbody2D>();

        __rigidbodyBall.velocity = Vector2.up * __ballModel.Speed;

        // Obtenha a direção do mouse em relação à posição inicial da bola
        Vector2 directionToMouse = GetDirectionToMouse();

        // Defina a direção da bola na direção do mouse
        __ballModel.Direction = directionToMouse;
        __rigidbodyBall.velocity = __ballModel.Direction * (__ballModel.Speed * 2f);
    }

    private Vector2 GetDirectionToMouse()
    {
        // Obtenha a posição do mouse na tela e converta para as coordenadas do mundo
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calcule a direção da bola em relação à posição do mouse (sem normalizar pela distância)
        return (mousePosition - transform.position).normalized;
    }
    public void PerfectAngleReflect(Collision2D other)
    {
        __ballModel.Direction = Vector2.Reflect(__ballModel.Direction, other.contacts[0].normal);
        AngleChange(__ballModel.Direction);
    }

    public void AngleChange(Vector2 direction)
    {
        __ballModel.Direction = direction;
        __rigidbodyBall.velocity = __ballModel.Direction * __ballModel.Speed;
    }

    public Vector2 CalcBallAngleReflect(Collision2D collision)
    {
        float playerPixels = 120f;

        float unityScaleHalfPlayerPixels = playerPixels / 2 / 100f;

        float scaleFactorToPutIn1Do180Range = 1.5f;

        float angleDegUnityScale = (collision.transform.position.x - transform.position.x + unityScaleHalfPlayerPixels) * scaleFactorToPutIn1Do180Range;

        float angleDeg = angleDegUnityScale * 100f;

        float angleRad = angleDeg * Mathf.PI / 180f;

        return new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}
