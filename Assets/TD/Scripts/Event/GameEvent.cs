using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Game Event", menuName = "Game/Event", order =1)]
public class GameEvent : ScriptableObject
{
    public event Action onEventRaised;

    public void Raise()
    {
        onEventRaised?.Invoke();
    }
}
