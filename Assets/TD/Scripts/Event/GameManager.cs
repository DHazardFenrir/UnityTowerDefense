using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XP.Pathfinding;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameEvent onGameStart = default;
    [SerializeField] GameEvent onGameOver = default;

    [ContextMenu ("Start Game")]
    public void StartGame()
    {
        onGameStart.Raise();
        Debug.Log("Estoy iniciando");
    }

    [ContextMenu("Game Over")]
    public void GameOver()
    {
        onGameOver.Raise();
    }
}
