using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    private BrickModel __brickModel;
    // Start is called before the first frame update
    void Start()
    {
        __brickModel = GetComponent<BrickModel>();
    }

    public void TakeDamage(float damage)
    {
        __brickModel.Life -= damage;
        if (__brickModel.Life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
