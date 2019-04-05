using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Base values if none are given from weapon
    public int bulletDamage = 25;
    public float bulletSpeed = 25.0f;
    public Vector2 bulletDirection = new Vector2(0.0f, 0.0f);
    public float bulletScale = 1.0f;
    public float bulletGravity = 0.0f;
   
    //Bullet rigid body reference
    public Rigidbody2D rb;

    public void SetBulletParameters(int bDmg, float bSpd, Vector2 bDir, float bScale = 1.0f, float bGrav = 0.0f)
    {
        bulletDamage = bDmg;
        bulletSpeed = bSpd;
        bulletDirection = bDir;
        bulletScale = bScale;
        bulletGravity = bGrav;
    }

    void Start()
    {
        rb.velocity = bulletDirection * bulletSpeed;
        rb.transform.localScale = new Vector3(bulletScale, bulletScale, bulletScale);
        rb.gravityScale = bulletGravity;
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
