using UnityEngine;
using UnityEngine.Tilemaps;

public class TileController : MonoBehaviour
{
    private Tilemap currentTilemap; // O Tilemap atual que está sendo verificado

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision in " + collision.gameObject.tag);
        // Verifica se a colisão é com um objeto que possui a tag "Player" (ou a tag correta do seu objeto)
        if (collision.gameObject.CompareTag("Breakable"))
        {

        }
    }
}
