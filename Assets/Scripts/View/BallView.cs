using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallView : MonoBehaviour
{
    public BallController __ballController;
    public float totalCollision = 0;
    private TileController tileController;

    // Start is called before the first frame update
    void Start()
    {
        tileController = GameObject.Find("WallsBreak").GetComponent<TileController>();
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

        // if (collision.gameObject.CompareTag("Bullet"))
        // {
        //     AudioSource.PlayClipAtPoint(__ballController.__ballModel.FragmentEndEffect, transform.position);
        //     Destroy(gameObject);
        //     return;
        // }

        if (__ballController.__ballModel.FragmentEffect != null)
        {
            AudioSource.PlayClipAtPoint(__ballController.__ballModel.FragmentEffect, transform.position);
        }
        print(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direction = __ballController.CalcBallAngleReflect(collision);
            __ballController.AngleChange(direction);
        }
        else if (collision.gameObject.CompareTag("BreakableWall"))
        {
            Vector3 hitPosition = collision.contacts[0].point;
            // print(collision.contacts.Length);
            // print(collision.contacts[0].point);
            // print(collision.contacts[0].point.x);
            // print(collision.contacts[0].point.y);
            tileController.RemoveTileAtPosition(hitPosition);

            __ballController.PerfectAngleReflect(collision);
        }
        else
        {
            __ballController.PerfectAngleReflect(collision);
        }

        totalCollision++;
    }
}