using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 25f;
    
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right *  speed;
    }

    
    void Update()
    {
        
    }
}
