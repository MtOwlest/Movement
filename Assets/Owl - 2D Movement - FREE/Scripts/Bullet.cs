using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject bullet;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("BulletPrefab");
    }

    
    void Update()
    {
        
    }

    IEnumerator BulletPrefab()
    {
        rb.gravityScale = 0;

        yield return new WaitForSeconds(5);

        rb.gravityScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
