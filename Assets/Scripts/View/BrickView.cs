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

    public void PerformTakeDamage(float damage)
    {
        __brickController.TakeDamage(damage);
    }
}
