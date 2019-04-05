using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    //Shot type struct
    public enum ShotType
    {
        SINGLE = 0,
        AUTO = 1,
        BURST = 2,
        SPREAD = 3,
        EXPLOSIVE = 4,
        RADIAL = 5
    }

    //Weapon firemode struct
    public struct FireMode
    {
        public ShotType shotType;  //ShotType
        public int fireRate;       //Shots per second
        public int ammoCapacity;   //Bullets per clip
        public int reloadTime;
        public int bulletDamage;   
        public float bulletSpeed; 

        //Default values etc
        public FireMode(ShotType st = ShotType.SINGLE, int fr = 10, int ac = 10, int rt = 1, int bd = 25, float bs = 25) 
        {
            shotType = st;
            fireRate = fr;
            ammoCapacity = ac;
            reloadTime = rt;
            bulletDamage = bd;
            bulletSpeed = bs;
        }
    }

    //The weapons bullet varibles
    public FireMode fireMode = new FireMode(ShotType.SINGLE, 10, 10, 1, 25, 25.0f);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().SetBulletParameters(fireMode.bulletDamage, fireMode.bulletSpeed);
    }
}
