using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private BallModel __ballModel;
    private Rigidbody2D __rigidbodyBall;
    // Start is called before the first frame update
    void Start()
    {
        __ballModel = GetComponent<BallModel>();
        __rigidbodyBall = GetComponent<Rigidbody2D>();

        __rigidbodyBall.velocity = Vector2.up * __ballModel.Speed;
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
