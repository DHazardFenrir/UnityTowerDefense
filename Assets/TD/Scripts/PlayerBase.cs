using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBase : MonoBehaviour, IDamageable
{
    [SerializeField] int startHP = 100;
    [SerializeField] GameEvent onGameStart = default;
    public event Action<int> onHPChanged;
    private int currentHP;
    [SerializeField] GameEvent onGameOver = default;

    private void OnEnable()
    {
        onGameStart.onEventRaised += RestartHP;
    }

    private void OnDisable()
    {
        onGameStart.onEventRaised -= RestartHP;
    }

    private void Start()
    {
        RestartHP();
    }
    public void RestartHP()
    {
        currentHP = startHP;
    }
    public void Damage(int amount)
    {
        currentHP -= amount;
        onHPChanged?.Invoke(currentHP);

        if(currentHP <= 0)
        {
            currentHP = 0;
            onGameOver.Raise();

        }

        onHPChanged?.Invoke(currentHP);
    }
}
