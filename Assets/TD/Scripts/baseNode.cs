using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseNode : MonoBehaviour
{
    public bool IsEmpty { get { return playerBase == null; } }
    public bool IsEnemyBaseEmpty {  get { return waveSpawner == null; } }

    public PlayerBase playerBase { get; private set; }
    

    public WaveSpawner waveSpawner { get; private set; }

    public PlayerBase test_playerbase;
    public WaveSpawner test_waveSpawner;

    private void Start()
    {
        playerBase = test_playerbase;
        waveSpawner = test_waveSpawner;
    }
    public void SetPlayerBase(PlayerBase PlayerBase)
    {
        playerBase = PlayerBase;

    }

    public void SetEnemyBase(WaveSpawner WaveSpawner)
    {
        waveSpawner = WaveSpawner;
    }

    
}
