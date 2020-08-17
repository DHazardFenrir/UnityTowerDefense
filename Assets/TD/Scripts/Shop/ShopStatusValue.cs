using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shop Status", menuName = "GameEvent/Shop Status", order =1)]
public class ShopStatusValue : ScriptableObject
{
    public ShopStatus Status { get; private set; }

    private void Awake()
    {
        Status = ShopStatus.None;
    }
    public void SetStatus(ShopStatus status)
    {
        Status = status;
    }
 
}
public enum ShopStatus { None, Buying}
