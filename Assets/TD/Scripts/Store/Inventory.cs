using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int currentGold;
    public event Action<int> onGoldAmountChanged;

    private void Start()
    {
        onGoldAmountChanged?.Invoke(0);
    }
    public void AddGold(int amount)
    {
        currentGold += amount;
        onGoldAmountChanged?.Invoke(currentGold);
    }
}
