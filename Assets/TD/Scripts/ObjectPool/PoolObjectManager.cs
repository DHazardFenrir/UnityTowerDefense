using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjectManager : MonoBehaviour
{
    [SerializeField] GameObject objPrefab;
    [SerializeField] int poolSize;
    [SerializeField] bool prewarm = false;
    private Queue<GameObject> objPool;

   public static PoolObjectManager bulletManager;

    private void Awake()
    {
        if(bulletManager == null)
        {
            bulletManager = this;
        }
        else if(bulletManager != null)
        {
            Destroy(this);
        }
        objPool = new Queue<GameObject>();
    }


    private void Start()
    {
        if (prewarm)
            PrewarmPool();
       
    }

    public void PrewarmPool()
    {
        for (int i = 0; i < poolSize; i++)
        CreateObject(objPrefab);
    }

    public GameObject GetObjFromPool(Vector3 newposition, Quaternion newrotation)
    {
        if(objPool.Count== 0)
        CreateObject(objPrefab);
        
        GameObject newObjct = objPool.Dequeue();
       newObjct.transform.SetPositionAndRotation(newposition, newrotation);
        newObjct.SetActive(true);
        return newObjct;
    }

    public void ReturnObjToPool(GameObject obj)
    {
        obj.SetActive(false);
        objPool.Enqueue(obj);
    }

    public GameObject CreateObject(GameObject prefab)
    {
        GameObject newObject = Instantiate(objPrefab);
        objPool.Enqueue(newObject);
        newObject.SetActive(false);
        return newObject;
    }
}
