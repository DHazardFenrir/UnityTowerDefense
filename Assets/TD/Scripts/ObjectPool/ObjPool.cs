using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool 
{
   public GameObject Prefab { get; private set; }
    private Queue<GameObject> poolObjects;

    public ObjPool(GameObject prefab)
    {
        Prefab = prefab;
        poolObjects = new Queue<GameObject>();
    }
    




    public GameObject GetObjFromPool(Vector3 newposition, Quaternion newrotation)
    {
        if (poolObjects.Count == 0)
            CreateObject(Prefab);

        GameObject newObjct = poolObjects.Dequeue();
        newObjct.transform.SetPositionAndRotation(newposition, newrotation);
        newObjct.SetActive(true);
        return newObjct;
    }

    public void ReturnObjToPool(GameObject obj)
    {
        obj.SetActive(false);
        poolObjects.Enqueue(obj);
    }

    public GameObject CreateObject(GameObject prefab)
    {
        GameObject newObject = GameObject.Instantiate(Prefab);
        poolObjects.Enqueue(newObject);
        newObject.SetActive(false);
        return newObject;
    }
}
