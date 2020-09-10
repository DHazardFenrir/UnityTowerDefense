using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Rigidbody rb;
    private int damage;
 
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

  

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.Damage(damage);
            PoolManager.Instance.StoreBullet(this.gameObject);
        }
    }

    public void Init(int damage)
    {
        this.damage = damage;
        rb.velocity = transform.forward * speed;
        Invoke("StoreOnPool", 5f);
    }

    private void StoreOnPool()
    {
        PoolManager.Instance.StoreBullet(this.gameObject);
    }
}
