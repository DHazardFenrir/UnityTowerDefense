using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class PoolManager : MonoBehaviour
{
   
  

    private Dictionary<GameObject, ObjPool> pools;
    public static PoolManager Instance { get; private set; }

    private void Awake()
    {
        pools = new Dictionary<GameObject, ObjPool>();
        if(Instance == null)
        {
            Instance = this;
        }
    }
    
   
    ////Generic Methods/////
    
    public GameObject RequestObject (GameObject originalPrefab, Vector3 position, Quaternion rotation)
    {
        if (!pools.ContainsKey(originalPrefab))
        {
            ObjPool newPool = new ObjPool(originalPrefab);
            pools.Add(originalPrefab, newPool);
        }
        ObjPool pool = pools[originalPrefab];
        return  pool.GetObjFromPool(position, rotation);
    }

    public void StoreObj(GameObject originalPrefab, GameObject obj)
    {
        if (!pools.ContainsKey(originalPrefab))
        {
            ObjPool newPool = new ObjPool(originalPrefab);
            pools.Add(originalPrefab, newPool);
        }
        ObjPool pool = pools[originalPrefab];
        pool.ReturnObjToPool(obj);
    }
}
