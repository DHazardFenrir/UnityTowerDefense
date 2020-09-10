using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab = default;
    private ObjPool bulletPool;

    public static PoolManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        bulletPool = new ObjPool(bulletPrefab);
    }

    public GameObject RequestBullet(Vector3 position,Quaternion rotation)
    {
        return bulletPool.GetObjFromPool(position, rotation);
    }

    public void StoreBullet (GameObject bullet)
    {
        bulletPool.ReturnObjToPool(bullet);
    }
}
