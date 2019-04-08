using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;

    public int health = 250;

    public Weapon activeWeapon;
    public int activeWeaponID = 0;
    public int numWeapons = 0;

    public Dictionary<int, Weapon> weapons = new Dictionary<int, Weapon>();
    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE
        //Cycle through the weapons
        if (Input.GetButtonDown("CycleDown"))
        {
            SetActiveWeapon(-1);
        }
        if (Input.GetButtonDown("CycleUp"))
        {
            SetActiveWeapon(1);
        }
#endif
#if UNITY_ANDROID || IOS
        //Touch the bottom right hand side of the screen to shoot with android
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began && touch.position.x > (Camera.main.pixelWidth / 3) && touch.position.y > (Camera.main.pixelHeight / 2))
            {
                SetActiveWeapon(1);
                //Dont want to shoot more than once
                break;
            }
        }
#endif
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
            health -= enemy.power;
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
            Vector3 newPos = new Vector3(gun.handlePoint.transform.localPosition.x * gun.transform.localScale.x, gun.handlePoint.transform.localPosition.y * gun.transform.localScale.y, 0.0f);
            gun.transform.localPosition = -newPos;

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
        Heart heart = collision.GetComponent<Heart>();
        if(heart != null)
        {
            health += 50;
            Destroy(heart.gameObject);
        }
    }
}
