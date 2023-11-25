using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private List<GameObject> bricks = new List<GameObject>();

    void Start()
    {
        PopulateBrickList();
    }
    public void DamageBrick(GameObject brickObject, float damage)
    {
        BrickController brickController = brickObject.GetComponent<BrickController>();
        if (brickController != null)
        {
            brickController.TakeDamage(damage);
            bricks.Remove(brickObject); // Remove o tijolo da lista quando é destruído
        }
    }

    // Método para preencher a lista de tijolos
    public void PopulateBrickList()
    {
        GameObject[] allBricks = GameObject.FindGameObjectsWithTag("Breakable");
        bricks.Clear(); // Limpa a lista antes de preenchê-la novamente
        bricks.AddRange(allBricks);
    }

}
