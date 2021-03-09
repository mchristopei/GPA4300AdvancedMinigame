using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 static class KeyBoardManager
 {

    private static KeyCode AimKey = KeyCode.E;
    private static KeyCode CrouchKey = KeyCode.Q;
    private static KeyCode ReloadKey = KeyCode.H;
    private static KeyCode LoveKey = KeyCode.L;
    private static KeyCode MeeleeKey = KeyCode.Y;
    private static KeyCode GrenadeKey = KeyCode.P;
    private static KeyCode ShootKey = KeyCode.Mouse0;
    private static KeyCode switchWeaponKey = KeyCode.X;
    private static KeyCode UseItemKey = KeyCode.K;
    private static KeyCode switchItemsKey = KeyCode.I;

    public static bool RifleActive;
    public static bool PistolActive;
    public static bool HeavyActive;
    public static bool SniperActive;
    public static bool switchItems()
    {
        if(Input.GetKey(switchItemsKey)) { return true; }
        else { return false; }
    }
    public static bool useItemKey()
    {
        if (Input.GetKey(UseItemKey)) { return true; }
        else { return false; }
    }
    public static bool AimPressed()
    {
        if(Input.GetKey(AimKey)){ return true; }
        else { return false; }
    }
    public static bool CrouchPressed()
    {
        if (Input.GetKey(CrouchKey)) { return true; }
        else { return false; }
    }
    public static bool ReloadPressed()
    {
        if (Input.GetKeyDown(ReloadKey)) { return true; }
        else { return false; }
    }
    public static bool ShowLovePressed()
    {
        if (Input.GetKey(LoveKey)) { return true; }
        else { return false; }
    }
    public static bool MeeleePressed()
    {
        if (Input.GetKey(MeeleeKey)) { return true; }
        else { return false; }
    }
    public static bool GrenadePressed()
    {
        if (Input.GetKey(GrenadeKey)) { return true; }
        else { return false; }
    }
    public static bool ShootPressed()
    {
        if (Input.GetKey(ShootKey)) { return true; }
        else { return false; }
    }
    public static bool PistolShootPressed()
    {
        if (Input.GetKeyDown(ShootKey)) { return true; }
        else { return false; }
    }
    public static bool SwitchWeaponPressed()
    {
        if (Input.GetKeyDown(switchWeaponKey)) { return true; }
        else { return false; }
    }
 }
