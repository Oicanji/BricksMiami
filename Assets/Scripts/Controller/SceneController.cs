using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.R))
        {
            CarregarPrimeiraFase();
        }
    }

    public void CarregarPrimeiraFase()
    {
        SceneManager.LoadScene("level1");
    }
}
