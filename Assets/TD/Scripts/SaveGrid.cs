using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;
using XP.Pathfinding;

public class SaveGrid : MonoBehaviour
{
   
    [SerializeField] GridManager gridManager;

    void Start()
    {
        CreatingAndSavingGrid();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatingAndSavingGrid()
    {
       
        string filename = "grid.save";
        string saveDirectoryName = "saves";
        string saveDirectoryPath = Path.Combine(Application.persistentDataPath, saveDirectoryName);
        string filePath = Path.Combine(saveDirectoryPath, filename);
        string saveData = "saved grid for the level";
       
        
        
      

        if (!Directory.Exists(Path.Combine(saveDirectoryPath)))
        {
            Directory.CreateDirectory(saveDirectoryPath);
        }

        Node[][] grid = gridManager.GetGridNodes();
        string[] tempString = new string[grid.Length];


        for (int i = 0; i < grid.Length; i++)
        {
            
            for (int j = 0; j < grid[i].Length; j++)
            {
               
                if (grid[i][j].IsVisitable)
                {
                    Debug.Log("o");
                   
                    tempString[i] += "o";










                }
                else
                {
                    Debug.Log("x");
                   
                    tempString[i] += "x";

                }


            }
        }
        
        Debug.Log("Save was saved in: " + filePath + saveData);
        File.WriteAllLines(filePath, tempString);


    }
}
