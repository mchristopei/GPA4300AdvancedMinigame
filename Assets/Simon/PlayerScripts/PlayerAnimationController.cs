﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator playerAnimator;
    private KeyBoardManager keyBoardManager;
    private bool aiming = false;
    private bool crouching = false;
    private bool shooting = false;
    private bool reloading = false;
    private bool meeleeing = false;
    private bool grenadeThrow = false;
    private bool showingLove = false;

    private bool rifleActive;
    private bool pistolActive;
    private bool sniperActive;
    private bool heavyActive;
    private void Start()
    {
        keyBoardManager = FindObjectOfType<KeyBoardManager>();
        playerAnimator = FindObjectOfType<PlayerAnimationController>().GetComponent<Animator>();
    }
    void Update()
    {
        KeyHandling("Aiming", keyBoardManager.AimPressed(), aiming);
        KeyHandling("Crouch", keyBoardManager.CrouchPressed(), crouching);
        playerAnimator.SetBool("Reload", keyBoardManager.isReloading);
        //playerAnimator.SetBool("Aiming", keyBoardManager.AimPressed());
        //KeyHandling("Reload", keyBoardManager.ReloadPressed(), reloading);
        KeyHandling("Meelee", keyBoardManager.MeeleePressed(), meeleeing);
        KeyHandling("Grenade", keyBoardManager.GrenadePressed(), grenadeThrow);
        KeyHandling("ShowLove", keyBoardManager.ShowLovePressed(), showingLove);
        KeyHandling("RifleActive", keyBoardManager.RifleActive, rifleActive);
        KeyHandling("PistolActive", keyBoardManager.PistolActive, pistolActive);
        KeyHandling("SniperActive", keyBoardManager.SniperActive, sniperActive);
        KeyHandling("HeavyActive", keyBoardManager.HeavyActive, heavyActive);
        if (keyBoardManager.RifleActive)
        {
            if(keyBoardManager.outOfAmmo)
            {
                playerAnimator.SetBool("Shoot", false);
            }
            else
            {
                playerAnimator.SetBool("Shoot", keyBoardManager.ShootPressed());
            }
        }
        
        if ((keyBoardManager.PistolActive || keyBoardManager.SniperActive || keyBoardManager.HeavyActive) && !keyBoardManager.outOfAmmo)
        {
            if (keyBoardManager.outOfAmmo)
            {
                playerAnimator.SetBool("Shoot", false);
            }
            else
            {
                playerAnimator.SetBool("Shoot", keyBoardManager.SingleShootPressed());
            }
        }
    }

    void KeyHandling(string parameter, bool key, bool action)
    {
        if (key)
        {
            action = true;
            playerAnimator.SetBool(parameter, true);
        }
        else
        {
            action = false;
            playerAnimator.SetBool(parameter, false);
        }
    }
}
