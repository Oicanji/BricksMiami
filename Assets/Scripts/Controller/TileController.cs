using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileController : MonoBehaviour
{
    public Tilemap __tilemap; // Referência para o Tilemap que contém os tiles

    void Start()
    {
        __tilemap = GetComponent<Tilemap>();
    }

    // if collision with ball destroy tile
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                __tilemap.SetTile(__tilemap.WorldToCell(hitPosition), null);
            }
        }
    }
}
