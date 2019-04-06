using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    //Override the base FireMode with variables that suit a pistol weapon
    private void Start()
    {
        fireMode = new FireMode(ShotType.SPREAD, 75, 24, 250, 15, 3, 25);
    }
}
