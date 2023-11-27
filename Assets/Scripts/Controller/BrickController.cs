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
        if (Random.Range(0.0f, 1.0f) < __brickModel.Evasion)
        {
            __brickModel.Life -= damage;
        }
        if (__brickModel.Life <= 0)
        {
            if (__brickModel.BreakEffect != null)
                AudioSource.PlayClipAtPoint(__brickModel.BreakEffect, transform.position);
            Destroy(gameObject);
            return;
        }
        if (__brickModel.HitEffect != null)
            AudioSource.PlayClipAtPoint(__brickModel.HitEffect, transform.position);
    }
}
