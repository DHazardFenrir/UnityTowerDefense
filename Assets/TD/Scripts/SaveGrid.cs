using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;
using XP.Pathfinding;

public class SaveGrid : MonoBehaviour
{
    [SerializeField] TextAsset file = default;
    private GridManager gridManager;

    void Start()
    {
        
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
        string Ex;
        string zero;
        string[] dataMatrix = new string[] { };
      

        if (!Directory.Exists(Path.Combine(saveDirectoryPath)))
        {
            Directory.CreateDirectory(saveDirectoryPath);
        }

        Node[][] grid = gridManager.GetGridNodes();
       
        for(int i = 0; i < grid.Length; i++)
        {
           for(int j = 0; j < grid[i].Length; j++)
            {
                if(grid[i][j].IsVisitable)
                {
                    Debug.Log("o");
                    Ex = grid[i][j].ToString();
                    Ex = "o";
                    
                    for (int k =0; k < dataMatrix.Length; k++)
                    {
                        dataMatrix[k] = Ex;
                    }
                   
                }
                else
                {
                    Debug.Log("x");
                    zero = grid[i][j].ToString();
                    zero = "x";
                    for (int k = 0; k < dataMatrix.Length; k++)
                    {
                        dataMatrix[k] = zero;
                    }
                }
            }
        }

    }
}
