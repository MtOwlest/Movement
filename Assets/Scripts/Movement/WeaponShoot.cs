using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPoint;
    private Rigidbody2D rb;
    public float speed;
    float NextShot;
    public float fireRate;

    void Start()
    {
        
        
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time > NextShot)
            {
                NextShot = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {

        bullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * speed);
    }
}
