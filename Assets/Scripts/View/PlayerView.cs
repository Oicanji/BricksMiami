using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private PlayerController __playerController;

    // Start is called before the first frame update
    void Start()
    {
        __playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float w = Input.GetAxis("Vertical");
        __playerController.Move(h, w);

    }
}
