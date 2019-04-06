using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halo : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        fireMode = new FireMode(ShotType.HALO, 50, 80, 250, 25, 8, 15);
    }
}
