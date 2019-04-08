using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halo : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        fireMode = new FireMode(ShotType.HALO, 50, 80, 150, 25, 16, 15);
        weaponName = "Halo";
    }
}
