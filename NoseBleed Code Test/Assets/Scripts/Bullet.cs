using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Base values if none are given from weapon
    public int bulletDamage = 25;
    public float bulletSpeed = 25.0f;
   
    //Bullet rigid body reference
    public Rigidbody2D rb;

    public void SetBulletParameters(int bd, float bs)
    {
        bulletDamage = bd;
        bulletSpeed = bs;
    }

    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //Check to see if we hit an enemy object
        Enemy enemy = otherObject.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(bulletDamage);
        }

        //Destroy the bullet on collision
        Destroy(gameObject);
    }
}
