using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XP.Pathfinding;


public class Enemy : MonoBehaviour, IDamageable
{
    public EnemyType Type { get { return type; } }
    [SerializeField] EnemyType type = default;
    private IMovable movable;
    private int currentHP;
    [SerializeField] int rewardGold = 10;

    [SerializeField] int startHP = 100;
    

    private void Awake()
    {
        movable = GetComponent<IMovable>();
    }

    public void Init(Node goal)
    {      
        int x = Mathf.RoundToInt(transform.position.x);
        int z = Mathf.RoundToInt(transform.position.z);
        Node start = FindObjectOfType<GridManager>().GetNodeAtPosition(x, z);

        if(start != null)
        {
            IPathfinder pathfinder = new BFS();
            Node[] nodes = pathfinder.FindPath(start, goal);
            movable.SetPath(nodes);
        }
        else
        {
            Debug.LogWarning("Enemy is not in a valid Node.");
        }
        
    }

    public void Damage(int amount)
    {
        currentHP -= amount;
        if(currentHP <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(this.gameObject);
        FindObjectOfType<Inventory>().AddGold(rewardGold); //Cambiar por otro metodo despues.
    }
}
