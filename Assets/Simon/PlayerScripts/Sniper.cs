using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Weapon
{
    public override void ConfigInitValues()
    {
        damage = 30f;
        range = 250f;
        maxAmmoAmount = 60f;
        magazineCapacity = 80f;
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
}
