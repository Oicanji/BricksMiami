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

        if (level == "title_screen")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                LoadScene("intro");
            }
        }
        else if (level == "game_over")
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                LoadScene("level_1");
            }
        }
    }

    public void LoadScene(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("game_over");
    }
}
