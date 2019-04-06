using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int power = 25;

    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Death EXPLOSIONS
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
