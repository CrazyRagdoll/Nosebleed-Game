using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public GameObject haloWeapon;

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player)
        {
            Instantiate(haloWeapon, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
