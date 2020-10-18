using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;
using XP.Pathfinding;

public class SaveGrid : MonoBehaviour
{
   
    [SerializeField] GridManager gridManager;
    GameNode towerNode;
    baseNode gameBase;
    

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
        string[] tempString = new string[grid[0].Length];


        for (int i = 0; i < grid[0].Length; i++)
        {
            
            for (int j = 0; j < grid.Length; j++)
            {
                
                towerNode = grid[i][j].gameObject.GetComponent<GameNode>();
                gameBase = grid[i][j].gameObject.GetComponent<baseNode>();

                if(gameBase != null)
                {
                    if(!gameBase.IsEmpty && grid[i][j].IsVisitable)
                    {
                        Debug.Log("p");
                        tempString[i] += "p";
                    }

                    if(!gameBase.IsEnemyBaseEmpty && grid[i][j].IsVisitable)
                    {
                        Debug.Log("e");
                        tempString[i] += "e";

                    }
                }

                if (!towerNode.IsEmpty && grid[i][j].IsVisitable )
                {
                    Debug.Log("t");

                    if(towerNode.getTower().GetData().baseStats.TorretNumber.Equals(1))
                    tempString[i] += "1";
                    if (towerNode.getTower().GetData().baseStats.TorretNumber.Equals(2))
                        tempString[i] += "2";
                    if (towerNode.getTower().GetData().baseStats.TorretNumber.Equals(3))
                        tempString[i] += "3";
                }
                else if(grid[i][j].IsVisitable && towerNode.IsEmpty && gameBase == null)
                {
                   
                    
                    Debug.Log("o");
                   
                    tempString[i] += "o";











                }
                else if(!grid[i][j].IsVisitable && towerNode.IsEmpty && gameBase == null)
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
