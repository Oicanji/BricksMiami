using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerModel __playerModel;
    private Transform __transform;

    // Start is called before the first frame update
    void Start()
    {
        __playerModel = GetComponent<PlayerModel>();
        __transform = GetComponent<Transform>();
    }

    public void Move(float h)
    {
        if ((__transform.position.x > -4.5f && h < 0) || (__transform.position.x < 4.5f && h > 0))
        {
            __transform.Translate(Vector2.right * (h * __playerModel.Speed * Time.deltaTime));
        }
    }
}
