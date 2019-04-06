using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstRifle : Weapon
{
    //Override the base FireMode with variables that suit a pistol weapon
    private void Start()
    {
        fireMode = new FireMode(ShotType.BURST, 50, 18, 150, 20, 3, 25);
        weaponName = "Burst Rifle";
    }
}
