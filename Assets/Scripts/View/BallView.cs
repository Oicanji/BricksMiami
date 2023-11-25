using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallView : MonoBehaviour
{
    private BallController __ballController;
    public TileController __tileController;

    // Start is called before the first frame update
    void Start()
    {
        __ballController = GetComponent<BallController>();
        __tileController = GameObject.Find("Tile").GetComponent<TileController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Breakable"))
        {
            __ballController.PerfectAngleReflect(collision);

        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            __ballController.PerfectAngleReflect(collision);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            print("Player");
            Vector2 direction = __ballController.CalcBallAngleReflect(collision);
            __ballController.AngleChange(direction);
        }
    }
}
