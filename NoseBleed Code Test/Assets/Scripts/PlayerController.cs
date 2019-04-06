﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;

    public int Health = 100;

    public Weapon activeWeapon;
    static int activeWeaponID = 0;
    static int numWeapons = 0;

    public Dictionary<int, Weapon> weapons = new Dictionary<int, Weapon>();

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            //Game over
        }
        
        //Cycle through the weapons
        if (Input.GetButtonDown("CycleDown"))
        {
            SetActiveWeapon(-1);
        }
        if (Input.GetButtonDown("CycleUp"))
        {
            SetActiveWeapon(1);
        }
    }

    private void SetActiveWeapon(int next)
    {
        //If we have more than 1 weapon
        if(weapons.Count > 1)
        {
            //Disable the current weapon
            weapons[activeWeaponID].isActive = false;
            weapons[activeWeaponID].GetComponent<SpriteRenderer>().enabled = false;

            //If we're going too high out of bounds
            if ((activeWeaponID + next) == numWeapons)
            {
                activeWeaponID = 0;
            }   
            //Too low out of bounds...
            else if ((activeWeaponID + next) < 0)
            {
                activeWeaponID = numWeapons - 1;
            }
            //otherwise it's OK!
            else
            {
                activeWeaponID += next;
            }

            //Enable the new weapon
            weapons[activeWeaponID].isActive = true;
            weapons[activeWeaponID].GetComponent<SpriteRenderer>().enabled = true;
            activeWeapon = weapons[activeWeaponID];
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
        Weapon gun = collision.GetComponent<Weapon>();
        if (gun != null)
        {
            //Add it to the list of guns
            gun.transform.SetParent(transform.Find("Guns"));

            //Set its position on the player
            gun.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            gun.transform.localPosition -= (gun.handlePoint.transform.localPosition/2);

            //Flip the weapon so it faces the same direction as the player
            gun.transform.rotation = transform.rotation;

            //If we dont have a weapon make it our current weapon
            if(activeWeapon == null)
            {
                gun.isActive = true;
                activeWeapon = gun;
                activeWeaponID = 0;
            } else
            {
                //Otherwise hide it and keep it inactive
                gun.GetComponent<SpriteRenderer>().enabled = false;
            }
            
            weapons.Add(numWeapons++, gun);
        }
    }
}