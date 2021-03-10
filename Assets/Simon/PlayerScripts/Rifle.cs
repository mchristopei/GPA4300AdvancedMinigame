using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rifle : Weapon
{
    public override void ConfigInitValues()
    {
        damage = 5f;
        range = 50f;
        maxAmmoAmount = 200f;
        magazineCapacity = 50f;
        timeBetweenShots = 0.25f;

        RegularFov = 140;
        AimFov = 50;

        regNearClippingPlane = 0.01f;
        aimNearClippingPlane = 0.75f;
    }
    public override void GetInput()
    {
        if (KeyBoardManager.ShootPressed())
        {
            isShooting = true;
        }
    }
}
