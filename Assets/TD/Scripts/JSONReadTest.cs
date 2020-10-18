using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;


public class JSONReadTest : MonoBehaviour
{
    public StatsData data;
    void Start()
    {
        Save_Example();
        Read_Example();
    }

 private void Save_Example()
    {
        StatsData data = new StatsData();
        data.damage = 10;
        data.range = 3.5f;
        data.towerName = "Nombre";

        string json = JsonUtility.ToJson(data, true);
        SaveJsonToFile(json);
    }

    private void SaveJsonToFile(string json)
    {
        string saveDirectoryName = "saves";
        string saveDirectoryPath = Path.Combine(Application.persistentDataPath, saveDirectoryName);

        string filename = "save.json";
        string filePath = Path.Combine(saveDirectoryPath, filename);

        if (!Directory.Exists(saveDirectoryName))
        {
            Directory.CreateDirectory(saveDirectoryName);
        }

        Debug.Log("JSON saved: " + filePath);
        File.WriteAllText(filePath, json);
    }

    private void Read_Example()
    {
        string json = ReadJsonFile();
        StatsData jsonData = JsonUtility.FromJson<StatsData>(json);

        data = jsonData;
    }


    public string ReadJsonFile()
    {
        string saveDirectoryName = "saves";
        string saveDirectoryPath = Path.Combine(Application.persistentDataPath, saveDirectoryName);

        string filename = "save.json";
        string filePath = Path.Combine(saveDirectoryPath, filename);

        if (!Directory.Exists(saveDirectoryPath))
        {
            Directory.CreateDirectory(saveDirectoryPath);
        }
        string text = File.ReadAllText(filePath);
        return text;

    }

    public void Read_SimpleJSON()
    {
        string json = ReadJsonFile();

        
    }
}


[System.Serializable]
public class StatsData
{
    public int damage;
    public float range;
    public string towerName;
}
