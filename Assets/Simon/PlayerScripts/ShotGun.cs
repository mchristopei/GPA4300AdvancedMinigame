using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
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
        if (KeyBoardManager.SingleShootPressed())
        {
            isShooting = true;
        }
    }
}
