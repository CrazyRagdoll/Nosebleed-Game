using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInfoText : MonoBehaviour
{
    public GameController gameInfo;
    public Text ammoText;

    void Update()
    {
        Weapon weaponInfo = gameInfo.player.GetComponent<PlayerController>().activeWeapon;
        if (weaponInfo != null) {
            ammoText.text =
                "WEAPON: " + weaponInfo.weaponName +
                "\nFIRE TYPE: " + weaponInfo.fireMode.shotType +
                "\nCLIP: " + (weaponInfo.ammoCount <= 0 ? "RELOADING" : weaponInfo.ammoCount.ToString()) +
                "\nFIRE RATE: " + weaponInfo.fireMode.fireRate +
                "\nRELOAD TIME: " + weaponInfo.fireMode.reloadTime + 
                "\nBULLET DAMAGE: " + weaponInfo.fireMode.bulletDamage + 
                "\nBULLET SPEED: " + weaponInfo.fireMode.bulletSpeed;
        } else
        {
            ammoText.text =
                "NO WEAPON! RUNNNNNNNNNNNNNNNNNN";
        }
    }
}
