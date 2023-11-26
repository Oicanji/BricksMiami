using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private string level;

    void Start()
    {
        level = SceneManager.GetActiveScene().name;
    }

    void Update()
    {

        if (level == "inicio")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                CarregarLevel("level1");
            }
        }
        else if (level == "GameOver")
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                CarregarLevel("level1");
            }
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
