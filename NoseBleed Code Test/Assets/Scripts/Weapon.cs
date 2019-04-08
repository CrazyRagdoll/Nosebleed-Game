using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform handlePoint;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public string weaponName = "Weapon";

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
    [System.Serializable]
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
        public FireMode(ShotType ShotType = ShotType.SINGLE, int FireRate = 25, int AmmoCapacity = 12, int ReloadTime = 100, int BulletDamage = 25, int BulletSpecialAmmo = 3, float BulletSpeed = 25.0f) 
        {
            shotType = ShotType;
            fireRate = FireRate;
            ammoCapacity = AmmoCapacity;
            reloadTime = ReloadTime;
            bulletDamage = BulletDamage;
            bulletSpecialAmount = BulletSpecialAmmo;
            bulletSpeed = BulletSpeed;
        }
    }

    //The weapons variables
    public FireMode fireMode;

    //Used to moderate weapon functionality, delay shot speed, add reload timer and ammo etc
    int fireTic = 0, reloadTic = 0;
    public int ammoCount = 0;
    public bool isActive = false;

    //Use fixed update for tic updates
    public void FixedUpdate()
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
    public void Update()
    {
        //If we shoot
        if (Input.GetButton("Fire1") && isActive)
        {
            //Do we have ammo?
            if (ammoCount > 0)
            {
                //Are we trying to shoot too fast?
                if (fireTic > fireMode.fireRate)
                {
                    Shoot();
                    fireTic = 0;
                }
            }
        }
        else if (Input.GetAxis("Fire1") > 0 && isActive)
        {
            //Do we have ammo?
            if (ammoCount > 0)
            {
                //Are we trying to shoot too fast?
                if (fireTic > fireMode.fireRate)
                {
                    Shoot();
                    fireTic = 0;
                }
            }
        }

        //Bouncy animation when idle
        if (!transform.parent)
        {
            IdleAnim();
        }

    }

    float anim;
    void IdleAnim()
    {
        anim += 0.05f;
        transform.localPosition += new Vector3(0.0f, (Mathf.Sin(anim)/50), 0.0f);
    }

    public void Shoot()
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

    public void FireBullet(int bDmg, float bSpd, Vector2 bDir, float bScale = 1.0f, float bGrav = 0.0f)
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().SetBulletParameters(bDmg, bSpd, bDir, bScale, bGrav);
        ammoCount--;
    }

    public void SingleShot()
    {
        FireBullet(fireMode.bulletDamage, fireMode.bulletSpeed, transform.right);
    }

    public IEnumerator BurstShot()
    {
        for (int i = 0; i < fireMode.bulletSpecialAmount; i++)
        {
            FireBullet(fireMode.bulletDamage, fireMode.bulletSpeed, transform.right);
            yield return new WaitForSeconds(0.075f);
        }
    }

    public void SpreadShot()
    {
        for (int i = 0; i < fireMode.bulletSpecialAmount; i++)
        {
            Vector3 newDir = new Vector3(transform.right.x, 0.35f - (0.7f * (i/(fireMode.bulletSpecialAmount-1.0f))), 0.0f);
            FireBullet(fireMode.bulletDamage, fireMode.bulletSpeed, newDir.normalized);
        }
    }

    public void ExplosiveShot()
    {

    }

    public void HaloShot()
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

    public void GravShot()
    {
        FireBullet(fireMode.bulletDamage, fireMode.bulletSpeed, new Vector3(transform.right.x -0.5f, 0.5f, 0.0f), 1.0f, 20.0f);
    }

    public void BigShot()
    {
        FireBullet(fireMode.bulletDamage, fireMode.bulletSpeed, transform.right, 2.5f);
    }

}
