using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseController : MonoBehaviour
{
    private GameObject playerCard;
    private GameObject playerSelect;
    private GameObject yeCard;
    private GameObject yeSelect;
    private GameObject miguelCard;
    private GameObject miguelSelect;
    private GameObject oliviaCard;
    private GameObject oliviaSelect;
    private string filePath;
    private CheatsData cheatsData;
    private List<GameObject> selects = new List<GameObject>();
    public int actualPlayer;
    public Sprite kayneImage;
    void Start()
    {
        playerCard = GameObject.Find("Player");
        playerSelect = GameObject.Find("SelectPlayer");
        yeCard = GameObject.Find("Ye");
        yeSelect = GameObject.Find("SelectYe");
        miguelCard = GameObject.Find("Miguel");
        miguelSelect = GameObject.Find("SelectMiguel");
        oliviaCard = GameObject.Find("Oliva");
        oliviaSelect = GameObject.Find("SelectOliva");
        filePath = Application.persistentDataPath + "/cheatsData.json";
        cheatsData = LoadCheatsData();

        miguelSelect.SetActive(false);
        yeSelect.SetActive(false);
        oliviaSelect.SetActive(false);

        selects.Add(playerSelect);

        actualPlayer = 0;

        if (cheatsData.monarkCheatActivated)
        {
            selects.Add(yeSelect);
            cardEnable(yeCard, true);
        }

        if (cheatsData.miguelCheatActivated)
        {
            selects.Add(miguelSelect);
            cardEnable(miguelCard);
        }

        if (cheatsData.beicolaCheatActivated)
        {
            selects.Add(oliviaSelect);
            cardEnable(oliviaCard);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (actualPlayer < selects.Count - 1)
            {
                selects[actualPlayer].SetActive(false);
                actualPlayer++;
                selects[actualPlayer].SetActive(true);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (actualPlayer > 0)
            {
                selects[actualPlayer].SetActive(false);
                actualPlayer--;
                selects[actualPlayer].SetActive(true);
            }
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            PlayCharacter playCharacter = selects[actualPlayer].GetComponent<PlayCharacter>();
            playCharacter.Play();
        }
    }

    private void cardEnable(GameObject card, bool is_the_fucking_kayne_west = false)
    {
        Image cardImage = card.transform.Find("CharImage").GetComponent<Image>();
        cardImage.color = new Color(1, 1, 1, 1);
        TextMeshProUGUI title = card.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        if (is_the_fucking_kayne_west)
        {
            cardImage.sprite = kayneImage;
            title.text = "MR.YE";
        }
        TextMeshProUGUI unlock = card.transform.Find("Unlock").GetComponent<TextMeshProUGUI>();
        unlock.color = new Color(1, 1, 1, 0);
        TextMeshProUGUI desc = card.transform.Find("Desc").GetComponent<TextMeshProUGUI>();
        desc.color = new Color(1, 1, 1, 1);
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
