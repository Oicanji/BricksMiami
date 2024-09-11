using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;
    private int totalCollision;

    void Start()
    {
        bulletController = GetComponent<BulletController>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        totalCollision++;
        bulletController.bulletModel.Speed *= 1.4f; // TODO: Permitir ajuste de velocidade de fragmentação

        // Tocar efeito de fragmentação
        if (bulletController.bulletModel.FragmentEffect != null)
        {
            AudioSource.PlayClipAtPoint(bulletController.bulletModel.FragmentEffect, transform.position);
        }

        HandleCollision(collision);

        // Limite de fragmentação atingido, destruir a bala
        if (bulletController.bulletModel.LimitFragmentation <= totalCollision)
        {
            AudioSource.PlayClipAtPoint(bulletController.bulletModel.FragmentEndEffect, transform.position);
            bulletController.DestroyAfterTrail();
        }
    }

    void HandleCollision(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("BreakableWall")) return;

        bulletController.ReflectBullet(collision);
    }
}
