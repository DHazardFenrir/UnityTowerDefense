using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameNode : MonoBehaviour
{
   public bool IsEmpty { get { return Tower == null; } }

    public Tower Tower { get; private set; }

    public Tower test_tower;

    private void Start()
    {
        Tower = test_tower;
    }
    public void SetTower(Tower tower)
    {
        Tower = tower;

    } 

    public Tower getTower()
    {
        return Tower;
    }

    //public void GetPlayerBase()
    //{
    //    PlayerBase playerbase = FindObjectOfType<PlayerBase>();
    //    Vector3 position = playerbase.transform.position;
    //    int x = Mathf.RoundToInt(position.x);
    //    int z = Mathf.RoundToInt(position.z);


    //}

    //public void GetEnemyBase()
    //{
    //   WaveSpawner enemyBase = FindObjectOfType<WaveSpawner>();
    //    Vector3 position = enemyBase.transform.position;
    //    int x = Mathf.RoundToInt(position.x);
    //    int z = Mathf.RoundToInt(position.z);


    //}
}
