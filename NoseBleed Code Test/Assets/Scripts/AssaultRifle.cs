using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon
{
    private void Start()
    {
        fireMode = new FireMode(ShotType.SINGLE, 5, 30, 100, 20, 0, 25);
    }

}
