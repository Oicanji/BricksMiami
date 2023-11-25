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
        GetTilesFromTileset();
    }

    void GetTilesFromTileset()
    {
        TileBase[] allTiles = __tilemap.GetTilesBlock(__tilemap.cellBounds); // Obtém todos os tiles do Tilemap

        if (allTiles != null)
        {
            for (int i = 0; i < allTiles.Length; i++)
            {
                Debug.Log("Tile encontrado: " + allTiles[i]);
            }
        }
    }

    // if collision with ball destroy tile
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                //rand numerber in 1 a 10 and < 3 destroy tile
                if (Random.Range(1, 10) < 3)
                {
                    hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                    hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                    __tilemap.SetTile(__tilemap.WorldToCell(hitPosition), null);
                }
            }
        }
    }
}
