using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileController : MonoBehaviour
{
    private Tilemap __tilemap;

    void Start()
    {
        __tilemap = GetComponent<Tilemap>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            RemoveTileAtPosition(collision.transform.position);
        }
    }

    public void RemoveTileAtPosition(Vector3 position)
    {
        Vector2 raycastDirection = Vector2.up; // Ajuste a direção do raycast conforme necessário para o seu Tilemap
        float raycastDistance = 1f; // Ajuste a distância do raycast conforme necessário para o seu Tilemap

        RaycastHit2D[] hits = Physics2D.RaycastAll(position, raycastDirection, raycastDistance);

        foreach (RaycastHit2D hit in hits)
        {
            Tilemap hitTilemap = hit.collider.GetComponent<Tilemap>();
            if (hitTilemap != null)
            {
                Vector3Int cellPosition = hitTilemap.WorldToCell(hit.point);
                TileBase tile = hitTilemap.GetTile(cellPosition);

                if (tile != null)
                {
                    hitTilemap.SetTile(cellPosition, null);
                    print("Tile Removed!");
                    return;
                }
            }
        }

        print("No Tile Found at Position!");
    }

}
