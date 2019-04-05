using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    //Shot type enum
    public enum ShotType
    {
        SINGLE = 0,
        BURST = 1,
        SPREAD = 2,
        EXPLOSIVE = 3,
        HALO = 4,
        GRAV = 5,
        BIG = 6,

        SOME = 10,
        MORE = 11,
        COOL = 12,
        STUFF = 13
    }

    //Weapon firemode struct
    public struct FireMode
    {
        public ShotType shotType;  //ShotType
        public int fireRate;       //Shots per second
        public int ammoCapacity;   //Bullets per clip
        public int reloadTime;
        public int bulletDamage;
        public int bulletSpecialAmount; //For example burst shoots 3, spread shoots 5, halo 10
        public float bulletSpeed;

        //Default values etc
        public FireMode(ShotType st = ShotType.SINGLE, int fr = 25, int ac = 12, int rt = 100, int bd = 25, int bsa = 3, float bs = 25.0f) 
        {
            shotType = st;
            fireRate = fr;
            ammoCapacity = ac;
            reloadTime = rt;
            bulletDamage = bd;
            bulletSpecialAmount = bsa;
            bulletSpeed = bs;
        }
    }

    //The weapons variables
    public FireMode fireMode = new FireMode(ShotType.SINGLE, 25, 12, 100, 15, 1, 25.0f);

    //Used to moderate weapon functionality, delay shot speed, add reload timer and ammo etc
    int fireTic = 0, reloadTic = 0, ammoCount = 0;

    //Use fixed update for tic updates
    private void FixedUpdate()
    {
        //Regulate shooting speed
        fireTic++;

        //If we're out of ammo
        if (ammoCount <= 0)
        {   
            //Start reloading
            reloadTic++;
            //When we've reloaded for long enough
            if(reloadTic >= fireMode.reloadTime)
            {   
                //Reset ammo value and reloadTic
                ammoCount = fireMode.ammoCapacity;
                reloadTic = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If we shoot
        if (Input.GetButton("Fire1"))
        {   
            //Do we have ammo?
            if(ammoCount > 0)
            {  
                //Are we trying to shoot too fast?
                if(fireTic > fireMode.fireRate)
                {
                    Shoot();
                    fireTic = 0;
                }
            }
        }
    }

    private void Shoot()
    {
        switch (fireMode.shotType)
        {
            case ShotType.SINGLE:
                SingleShot();
                break;
            case ShotType.BURST:
                StartCoroutine(BurstShot());
                break;
            case ShotType.SPREAD:
                SpreadShot();
                break;
            case ShotType.EXPLOSIVE:
                ExplosiveShot();
                break;
            case ShotType.HALO:
                HaloShot();
                break;
            case ShotType.GRAV:
                GravShot();
                break;
            case ShotType.BIG:
                BigShot();
                break;
            default:
                SingleShot();
                break;
        }
    }

    private void FireBullet(int bDmg, float bSpd, Vector2 bDir, float bScale = 1.0f, float bGrav = 0.0f)
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().SetBulletParameters(bDmg, bSpd, bDir, bScale, bGrav);
        ammoCount--;
    }

    private void SingleShot()
    {
        FireBullet(fireMode.bulletDamage, fireMode.bulletSpeed, transform.right);
    }

    private IEnumerator BurstShot()
    {
        for (int i = 0; i < fireMode.bulletSpecialAmount; i++)
        {
            FireBullet(fireMode.bulletDamage, fireMode.bulletSpeed, transform.right);
            yield return new WaitForSeconds(0.075f);
        }
    }

    private void SpreadShot()
    {
        for (int i = 0; i < fireMode.bulletSpecialAmount; i++)
        {
            Vector3 newDir = new Vector3(transform.right.x, 0.5f - (1.0f * (i/(fireMode.bulletSpecialAmount-1.0f))), 0.0f);
            FireBullet(fireMode.bulletDamage, fireMode.bulletSpeed, newDir.normalized);
        }
    }

    private void ExplosiveShot()
    {

    }

    private void HaloShot()
    {
        float r = 360 / fireMode.bulletSpecialAmount;
        for (int i = 0; i < fireMode.bulletSpecialAmount; i++)
        {
            float newX = Mathf.Cos(i * (r * Mathf.Deg2Rad));
            float newY = Mathf.Sin(i * (r * Mathf.Deg2Rad));

            Vector3 newDir = new Vector3(newX, newY, 0.0f);
            FireBullet(fireMode.bulletDamage, fireMode.bulletSpeed, newDir);
        }
    }

    private void GravShot()
    {
        FireBullet(fireMode.bulletDamage, fireMode.bulletSpeed, new Vector3(transform.right.x -0.5f, 0.5f, 0.0f), 1.0f, 20.0f);
    }

    private void BigShot()
    {
        FireBullet(fireMode.bulletDamage, fireMode.bulletSpeed, transform.right, 2.0f);
    }

}
