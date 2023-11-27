using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallView : MonoBehaviour
{
    public BallController __ballController;
    public float totalCollision = 0;

    // Start is called before the first frame update
    void Start()
    {
        __ballController = GetComponent<BallController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (__ballController.__ballModel.LimitFragmentation <= totalCollision)
        {
            AudioSource.PlayClipAtPoint(__ballController.__ballModel.FragmentEndEffect, transform.position);
            Destroy(gameObject);
            return;
        }

        __ballController.__ballModel.Speed += __ballController.__ballModel.Speed * 0.4f;

        if (collision.gameObject.CompareTag("Bullet"))
        {
            AudioSource.PlayClipAtPoint(__ballController.__ballModel.FragmentEndEffect, transform.position);
            Destroy(gameObject);
            return;
        }

        AudioSource.PlayClipAtPoint(__ballController.__ballModel.FragmentEffect, transform.position);
        if (collision.gameObject.CompareTag("Breakable") ||
            collision.gameObject.CompareTag("Enemy") ||
            collision.gameObject.CompareTag("Wall")
        )
        {
            __ballController.PerfectAngleReflect(collision);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direction = __ballController.CalcBallAngleReflect(collision);
            __ballController.AngleChange(direction);
        }

        totalCollision++;
    }
}
