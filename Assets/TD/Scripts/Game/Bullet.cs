using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Rigidbody rb;
    private int damage;
    private GameObject originalPrefab;
    private Coroutine coroutine;
 
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
            PoolManager.Instance.StoreObj(originalPrefab,this.gameObject);
            StopCoroutine(coroutine);
        }
    }

    public void Init(int damage, GameObject originalPrefab)
    {
        this.originalPrefab = originalPrefab;
        this.damage = damage;
        rb.velocity = transform.forward * speed;
        //Invoke("StoreOnPool", 5f);
        coroutine = StartCoroutine(StoreOnPoolCoroutine());
    }

 

    private IEnumerator StoreOnPoolCoroutine()
    {
        yield return new WaitForSeconds(5f);
        PoolManager.Instance.StoreObj(originalPrefab, this.gameObject);
    }
}
