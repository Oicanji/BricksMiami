using UnityEngine;
using System.IO;
public class CheatUtil : MonoBehaviour
{
    private string[] cheats = new string[] { "miguel", "monark", "beicola" };
    private string currentInput = "";
    private CheatsData cheatsData;
    private string filePath;

    //alters componentes to activate cheats
    public SpriteRenderer logo;
    public AudioSource audioPlayer;
    public GameObject[] objectsWithTagWall;
    //miguel
    public Sprite miguelLogo;
    public AudioClip miguelEffect;
    //monark
    public AudioClip monarkEffect;
    public Sprite monarkBackground;
    //beicola
    public AudioClip beicolaEffect;

    void Start()
    {
        logo = GameObject.Find("title").GetComponent<SpriteRenderer>();
        audioPlayer = GameObject.Find("soundPlayer").GetComponent<AudioSource>();
        objectsWithTagWall = GameObject.FindGameObjectsWithTag("Wall");
        filePath = Application.persistentDataPath + "/cheatsData.json";
        cheatsData = LoadCheatsData();

        if (cheatsData.miguelCheatActivated)
        {
            Miguel();
        }
        if (cheatsData.monarkCheatActivated)
        {
            Monark();
        }
        if (cheatsData.beicolaCheatActivated)
        {
            Beicola();
        }
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            // Verifica se a tecla pressionada é uma letra ou um espaço
            if (Input.inputString.Length == 1 && (char.IsLetter(Input.inputString[0]) || Input.inputString[0] == ' '))
            {
                // Adiciona o caractere pressionado ao input atual
                currentInput += Input.inputString.ToLower();

                // Verifica se algum cheat foi inserido
                CheckCheats();
            }
        }
    }


    // Dentro do método CheckCheats():
    void CheckCheats()
    {
        foreach (string cheat in cheats)
        {
            if (currentInput.EndsWith(cheat))
            {
                switch (cheat)
                {
                    case "miguel":
                        if (!cheatsData.miguelCheatActivated)
                        {
                            audioPlayer.clip = miguelEffect;
                            Miguel();
                            cheatsData.miguelCheatActivated = true;
                            SaveCheatsData(cheatsData);
                        }
                        break;
                    case "monark":
                        if (!cheatsData.monarkCheatActivated)
                        {
                            audioPlayer.clip = monarkEffect;
                            Monark();
                            cheatsData.monarkCheatActivated = true;
                            SaveCheatsData(cheatsData);
                        }
                        break;
                    case "beicola":
                        if (!cheatsData.beicolaCheatActivated)
                        {
                            audioPlayer.clip = beicolaEffect;
                            Beicola();
                            cheatsData.beicolaCheatActivated = true;
                            SaveCheatsData(cheatsData);
                        }
                        break;
                }
                audioPlayer.Play();
                currentInput = "";
                break;
            }
        }
    }
    void Miguel()
    {
        Debug.Log("Miguel");
        audioPlayer.Play();
        logo.sprite = miguelLogo;
    }

    void Monark()
    {
        Debug.Log("Monark");
        audioPlayer.clip = monarkEffect;
        foreach (GameObject wall in objectsWithTagWall)
        {
            wall.GetComponent<SpriteRenderer>().sprite = monarkBackground;
        }
    }

    void Beicola()
    {
        Debug.Log("Beicola");
    }

    // Métodos para salvar e carregar dados

    private void SaveCheatsData(CheatsData data)
    {
        string jsonData = JsonUtility.ToJson(data);

        try
        {
            File.WriteAllText(filePath, jsonData);
            Debug.Log("Dados de cheats salvos com sucesso em: " + filePath);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Erro ao salvar dados de cheats: " + e.Message);
        }
    }

    private CheatsData LoadCheatsData()
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            return JsonUtility.FromJson<CheatsData>(jsonData);
        }
        else
        {
            Debug.LogWarning("Arquivo de dados de cheats não encontrado. Criando novo...");
            return new CheatsData();
        }
    }
}
