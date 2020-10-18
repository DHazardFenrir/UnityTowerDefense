using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections.Specialized;
using XP.Pathfinding;

public class PrintGrid : MonoBehaviour
{
   
    [SerializeField] GameObject node;
    [SerializeField] GameObject basicTorret;
    [SerializeField] GameObject landTorret;
    [SerializeField] GameObject aerialTorret;
    [SerializeField] GameObject enemyBase;
    [SerializeField] GameObject playerBase;
    // Start is called before the first frame update
    void Start()
    {
        PrintFileInSaves();
    }

    private void PrintFileInSaves()
    {
        string saveDirectoryName = "saves";
        string saveDirectoryPath = Path.Combine(Application.persistentDataPath, saveDirectoryName);
       
        string filename = "grid.save";
        string filePath = Path.Combine(saveDirectoryPath, filename);

        if (File.Exists(filePath))
        {
            string[] fileText = File.ReadAllLines(filePath);

            for (int i = 0; i < fileText.Length; i++)
            {
                string save = fileText[i];
                for (int j = 0; j < save.Length; j++)
                {
                    switch (save[j])
                    {
                        case 'o':
                             Instantiate(node, new Vector3(i, 0, j), Quaternion.identity);
                           
                            break;

                        case 'x':
                            GameObject newTile = Instantiate(node, new Vector3(i, 0, j), Quaternion.identity);
                            Node nodes = newTile.GetComponent<Node>();
                            nodes.NoVisitable();



                            break;
                        case '1':
                            Instantiate(node, new Vector3(i, 0, j), Quaternion.identity);
                            Instantiate(basicTorret, new Vector3(i, 0, j), Quaternion.identity);
                            break;

                        case '2':
                            Instantiate(node, new Vector3(i, 0, j), Quaternion.identity);
                            Instantiate(landTorret, new Vector3(i, 0, j), Quaternion.identity);
                            break;

                        case '3':
                            Instantiate(node, new Vector3(i, 0, j), Quaternion.identity);
                            Instantiate(aerialTorret, new Vector3(i, 0, j), Quaternion.identity);
                            break;

                        case 'p':
                            Instantiate(node, new Vector3(i, 0, j), Quaternion.identity);
                            Instantiate(playerBase, new Vector3(i, 0, j), Quaternion.identity);
                            break;

                        case 'e':
                            Instantiate(node, new Vector3(i, 0, j), Quaternion.identity);
                            Instantiate(enemyBase, new Vector3(i, 0, j), Quaternion.identity);
                            break;

                        default:
                            Debug.Log("El archivo no existe o exploto algo");
                            break;





                    }
                }
            }

            

        }
       


    }
}
