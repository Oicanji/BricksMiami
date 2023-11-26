using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.R))
        {
            CarregarLevel("level1");
        }
    }

    public void CarregarLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void CarregarCenaGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
