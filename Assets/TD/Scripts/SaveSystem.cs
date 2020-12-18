using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    private const string FILE_NAME = "save.data";
    private string path;

    public SaveSystem()
    {
        path = Path.Combine(Application.persistentDataPath, FILE_NAME);
    }

    public void Save(SaveData saveData)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(path);
        binaryFormatter.Serialize(file, saveData);
        file.Close();
    }

    public SaveData Load()
    {
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            SaveData data = (SaveData)binaryFormatter.Deserialize(file);
            file.Close();
            return data;
        }
        else
        {
            return new SaveData();
        }
    }
}

[System.Serializable]
public class SaveData
{
    public int score;
    public int wave;
    public int gold;
    public string playerName;
    public SerializedVector3 lastPosition;
    public SerializedVector3[] position;
}


//para guardar vectores, posiciones, etc

[System.Serializable]
public class SerializedVector3
{
    public float x;
    public float y;
    public float z;

    public SerializedVector3 (float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }

    public static SerializedVector3 FromVector3(Vector3 vector)
    {
        return new SerializedVector3(vector.x, vector.y, vector.z);
    }
}

