using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class KeyBoardManager : MonoBehaviour
 {
    [SerializeField] private KeyCode AimKey = KeyCode.E;
    [SerializeField] private KeyCode CrouchKey = KeyCode.Q;
    [SerializeField] private KeyCode ReloadKey = KeyCode.H;
    [SerializeField] private KeyCode LoveKey = KeyCode.L;
    [SerializeField] private KeyCode MeeleeKey = KeyCode.Y;
    [SerializeField] private KeyCode GrenadeKey = KeyCode.P;
    [SerializeField] private KeyCode ShootKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode switchWeaponKey = KeyCode.X;
    [SerializeField] private KeyCode UseItemKey = KeyCode.K;
    [SerializeField] private KeyCode switchItemsKey = KeyCode.I;


    public bool RifleActive = true;
    public bool PistolActive = false;
    public bool HeavyActive = false;
    public bool SniperActive = false;
    public bool isReloading = false;
    public bool outOfAmmo = false;
    public bool switchItems()
    {
        if(Input.GetKeyDown(switchItemsKey)) { return true; }
        else { return false; }
    }
    public bool useItemKey()
    {
        if (Input.GetKey(UseItemKey)) { return true; }
        else { return false; }
    }
    public bool AimPressed()
    {
        if(Input.GetKey(AimKey)){ return true; }
        else { return false; }
    }
    public bool CrouchPressed()
    {
        if (Input.GetKey(CrouchKey)) { return true; }
        else { return false; }
    }
    public bool ReloadPressed()
    {
        if (Input.GetKeyDown(ReloadKey)) { return true; }
        else { return false; }
    }
    public bool ShowLovePressed()
    {
        if (Input.GetKey(LoveKey)) { return true; }
        else { return false; }
    }
    public bool MeeleePressed()
    {
        if (Input.GetKey(MeeleeKey)) { return true; }
        else { return false; }
    }
    public bool GrenadePressed()
    {
        if (Input.GetKey(GrenadeKey)) { return true; }
        else { return false; }
    }
    public bool ShootPressed()
    {
        if (Input.GetKey(ShootKey)) { return true; }
        else { return false; }
    }
    public bool SingleShootPressed()
    {
        if (Input.GetKeyDown(ShootKey)) { return true; }
        else { return false; }
    }
    public bool SwitchWeaponPressed()
    {
        if (Input.GetKeyDown(switchWeaponKey)) { return true; }
        else { return false; }
    }
 }
