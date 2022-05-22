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
                NextShot = Time.time + fireRate;
                Shoot();
            }
        }

        
    }

    void Shoot()
    {
        var clone = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        clone.GetComponent<Rigidbody2D>().AddForce(clone.transform.right * speed);

        Destroy(clone, 10f);
    }
}
