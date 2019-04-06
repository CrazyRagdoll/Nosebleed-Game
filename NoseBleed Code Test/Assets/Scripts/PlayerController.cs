using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;

    public int Health = 100;

    public Weapon activeWeapon;

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            //Game over
        }
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
            //Add it to the list of guns
            weapon.transform.SetParent(transform.Find("Guns"));

            //Set its position on the player
            weapon.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            weapon.transform.localPosition -= (weapon.handlePoint.transform.localPosition/2);

            //Flip the weapon so it faces the same direction as the player
            weapon.transform.rotation = transform.rotation;
            
            //Set the weapon to active so it can shoot
            weapon.isActive = true;
            //Set the current players active weapon to the new one
            activeWeapon = weapon;
        }
    }
}
