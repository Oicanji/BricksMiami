using UnityEngine;
using System.IO;
using System;

public class SaveManager : MonoBehaviour
{
    private string filePath;

    void Start()
    {
        filePath = Application.persistentDataPath + "/cheatsData.json";
    }

    public void SaveCheatsData(CheatsData data)
    {
        string jsonData = JsonUtility.ToJson(data);

        try
        {
            File.WriteAllText(filePath, jsonData);
            Debug.Log("Dados de cheats salvos com sucesso em: " + filePath);
        }
        catch (Exception e)
        {
            Debug.LogError("Erro ao salvar dados de cheats: " + e.Message);
        }
    }

    // Restante do seu código...
}
