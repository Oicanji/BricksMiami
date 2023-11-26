using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CarregarPrimeiraFase();
        }
    }

    public void CarregarPrimeiraFase()
    {
        SceneManager.LoadScene("level1");
    }
}
