using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class FileReader : MonoBehaviour
{
    [SerializeField] TextAsset file = default;

    private void Start()
    {
        //PrintTextAsset(file);
        //PrintFileInDesktop();
        //WriteFileInDesktop("Message");
        //FileBytes();
        CreateBasicSaveFile();
    }

    private void CreateBasicSaveFile()
    {
        string filename = "file.save";
        string saveDirectoryName = "saves";
        string saveDirectoryPath = Path.Combine(Application.persistentDataPath, saveDirectoryName);
        string filePath = Path.Combine(saveDirectoryPath, filename);
        string saveData = "Este es mi save data";
        
        if(!Directory.Exists(Path.Combine(saveDirectoryPath)))
        {
            Directory.CreateDirectory(saveDirectoryPath);
        }
        File.WriteAllText(filePath, saveData);
        Debug.Log("Save was saved in: " + filePath);

    }
    private void FileBytes()
    {
        string directorypath = "C:\\Users\\kille\\Downloads";
        string filename = "File.txt";
        string path = Path.Combine(directorypath, filename); //directorypath + "\\" + filename;

        if (File.Exists(path))
        {
            byte[] bytes = File.ReadAllBytes(path);
            string fileText = System.Text.Encoding.Default.GetString(bytes);
            Debug.Log(fileText);

        }
        else
        {
            Debug.Log("File not found");
        }

    }
    private void WriteFileInDesktop(string mensaje)
    {
        string directorypath = "C:\\Users\\kille\\Downloads";
        string filename = "File.txt";
        string path = Path.Combine(directorypath, filename); //directorypath + "\\" + filename;

        if (File.Exists(path))
        {
            File.AppendAllText(path, mensaje);
            //File.WriteAllText(path, mensaje);
            //Debug.Log(fileText);
            Debug.Log("File was written successfully");

        }
        else
        {
            Debug.Log("File not found");
        }
    }
    private void PrintFileInDesktop()
    {
        string directorypath= "C:\\Users\\kille\\Downloads";
        string filename = "File.txt";
        string path = Path.Combine(directorypath, filename); //directorypath + "\\" + filename;

        if (File.Exists(path))
        {
            string fileText = File.ReadAllText(path);
            Debug.Log(fileText);

        }
        else
        {
            Debug.Log("File not found");
        }



    }

    private void PrintTextAsset(TextAsset textAsset)
    {
        Debug.Log(textAsset.text);
    }
}
