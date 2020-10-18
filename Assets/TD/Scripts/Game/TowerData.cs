using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName ="Game/TowerData", order =1)]
public class TowerData : ScriptableObject
{
    //stats
    public TowerBaseStats baseStats;
    public string towerName = "Tower Name";
    public Sprite sprite;
    public GameObject prefab;
    public Evolution[] evolutions;
    
}

[System.Serializable]
public struct TowerBaseStats
{
    public int damage;
    public float attackSpeed;
    public float range;
    public EnemyType[] types;
    public int TorretNumber;
}

[System.Serializable]
public struct Evolution
{
    public int cost;
    public TowerData tower;
}