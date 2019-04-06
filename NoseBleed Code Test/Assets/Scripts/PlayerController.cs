using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Health = 100;

    public Weapon activeWeapon;

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            //Game over
        }

        activeWeapon = GetComponentInChildren<Weapon>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Health -= enemy.power;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Weapon weapon = collision.GetComponent<Weapon>();
        if (weapon != null)
        {

        }
    }
}
