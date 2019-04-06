using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    //Override the base FireMode with variables that suit a pistol weapon
    private void Start()
    {
        fireMode = new FireMode(ShotType.SINGLE, 25, 12, 50, 15, 0, 25);
    }
}
