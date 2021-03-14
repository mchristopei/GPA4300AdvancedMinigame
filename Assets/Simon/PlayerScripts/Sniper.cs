using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Weapon
{
    public override void SetAmmoOnStart()
    {
        totalAmmoCount = ammunitionControl.sniperTotalAmmoCount;
        ammoLeftInMagazine = ammunitionControl.sniperAmmoInMagazine;
    }
    public override void ConfigInitValues()
    {
        damage = 30f;
        range = 250f;
        maxAmmoAmount = 60f;
        magazineCapacity = 8f;
        timeBetweenShots = 2f;

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
        ammunitionControl.sniperAmmoInMagazine = ammoLeftInMagazine;
        ammunitionControl.sniperTotalAmmoCount = totalAmmoCount;
    }
}
