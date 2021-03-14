using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void SetAmmoOnStart()
    {
        totalAmmoCount = ammunitionControl.pistolTotalAmmoCount;
        ammoLeftInMagazine = ammunitionControl.pistolAmmoInMagazine;
    }
    public override void ConfigInitValues()
    {
        damage = 20f;
        range = 50f;
        maxAmmoAmount = 50f;
        magazineCapacity = 10f;
        timeBetweenShots = 1f;

        RegularFov = 140;
        AimFov = 50;

        regNearClippingPlane = 0.01f;
        aimNearClippingPlane = 0.75f;
    }
    public override void GetInput()
    {
        if (keyBoardManager.SingleShootPressed())
        {
            isShooting = true;
        }
    }
    public override void setAmmoControlStats()
    {
        ammunitionControl.pistolAmmoInMagazine = ammoLeftInMagazine;
        ammunitionControl.pistolTotalAmmoCount = totalAmmoCount;
    }
}
