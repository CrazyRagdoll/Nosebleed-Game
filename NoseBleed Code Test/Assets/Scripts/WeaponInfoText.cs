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
        Weapon weaponInfo = playerInfo.activeWeapon;
        if (weaponInfo != null) {
            ammoText.text =
                "WEAPON: " + weaponInfo.weaponName +
                "\nFIRE TYPE: " + weaponInfo.fireMode.shotType +
                "\nCLIP: " + (weaponInfo.ammoCount <= 0 ? "RELOADING" : weaponInfo.ammoCount.ToString());
        } else
        {
            ammoText.text =
                "NO WEAPON!";
        }
    }
}
