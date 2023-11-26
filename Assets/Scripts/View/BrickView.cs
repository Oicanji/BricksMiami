using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickView : MonoBehaviour
{
    private BrickController __brickController;
    // Start is called before the first frame update
    void Start()
    {
        __brickController = GetComponent<BrickController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            __brickController.TakeDamage(1);
        }
    }
}
