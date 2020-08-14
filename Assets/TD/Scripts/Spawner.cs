using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XP.Pathfinding;

public class Spawner : MonoBehaviour, ISpawner
{
    [SerializeField] Wave[] waves;
    private Transform target = default;
    [SerializeField] float waveDelay = 5f;
    [SerializeField] float spawnRate = 1f;


    private GridManager gridManager;
    private Node targetNode;

  

    public void StartSpawn(Transform target)
    {
        //Find Grid Manager
        gridManager = FindObjectOfType<GridManager>();

        //Get the Target Node
        int x = Mathf.RoundToInt(target.position.x);
        int z = Mathf.RoundToInt(target.position.z);
        targetNode = gridManager.GetNodeAtPosition(x, z);

        if (targetNode == null)
        {
            Debug.LogWarning("Target is not in a valid Node");
        }
        else
        {
            StartCoroutine(SpawningRoutine());
        }
       
    }

    IEnumerator SpawningRoutine()
    {
        yield return null;
    }

    private void Spawn(GameObject prefab)
    {
        GameObject go = Instantiate(prefab, transform.position, Quaternion.identity);
        Enemy enemy = go.GetComponent<Enemy>();
        enemy.Init(targetNode);
    }
}
