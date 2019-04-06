using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInfoText : MonoBehaviour
{
    public PlayerController playerInfo;
    public Text ammoText;

    void Update()
    {
        Weapon weaponInfo = playerInfo.currentWeapon.GetComponent<Weapon>();
        if (weaponInfo != null) {
            ammoText.text =
                "WEAPON: " + weaponInfo.name +
                "\nFIRE TYPE: " + weaponInfo.fireMode.shotType +
                "\nAMMO: " + weaponInfo.ammoCount;
        } else
        {
            ammoText.text =
                "NO WEAPON EQUIP!";
        }
    }
}
