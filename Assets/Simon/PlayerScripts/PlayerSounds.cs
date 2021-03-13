using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private bool hasShot = false;
    private bool isMeeleeing = false;
    private bool isReloading = false;
    private bool grenadeReady = false;
    private bool throwingGrenade = false;
    [SerializeField] private AudioSource rifleShoot;
    [SerializeField] private AudioSource rifleReload;
    [SerializeField] private float rifleReloadTimeOffset = 0.25f;
    private float rifleDefaultReloadTimeOffset;
    [SerializeField] private float TimeBetweenShots = 0.1f;
    private float timeSinceLastShot = 0.0f;

    [SerializeField] private float meeleeTimeOffset = 0.5f;
    private float defaultMeeleeTimeOffset;

    private float timeSinceGrenadeReady = 0.0f;
    [SerializeField] private float grenadeThrowTimeOffset = 0.5f;
    private float grenadeThrowDefaultTimeOffset;

    [SerializeField] private AudioSource meelee;
    [SerializeField] private AudioSource grabGrenade;
    [SerializeField] private AudioSource throwGrenade;

    private KeyBoardManager keyBoardManager;
    void Start()
    {
        keyBoardManager = FindObjectOfType<KeyBoardManager>();
        defaultMeeleeTimeOffset = meeleeTimeOffset;
        rifleDefaultReloadTimeOffset = rifleReloadTimeOffset;
        grenadeThrowDefaultTimeOffset = grenadeThrowTimeOffset;
    }

    void Update()
    {
        GeneralSounds();
        if(keyBoardManager.RifleActive)
        {
            RifleSounds();
        }
    }
    void PlayWithOffset(float timeOffset, float defaultTimeOffset, bool condition, AudioSource audioSource)
    {
        if(condition)
        {
            timeOffset -= Time.deltaTime;
            if(timeOffset <= 0.0f)
            {
                timeOffset = defaultTimeOffset;
                condition = false;
                audioSource.Play();
            }
        }
    }
    private void GeneralSounds()
    {
        Meelee();
        Grenade();
    }
    void Grenade()
    {
        if(keyBoardManager.GrenadePressed() && !grenadeReady)
        {
            grenadeReady = true;
        }
        if(grenadeReady && timeSinceGrenadeReady == 0.0f)
        {
            grabGrenade.Play();
        }
        if(grenadeReady)
        {
           timeSinceGrenadeReady += Time.deltaTime;
           
        }
        if(!keyBoardManager.GrenadePressed() && grenadeReady)
        {
            grenadeReady = false;
            throwingGrenade = true;
            timeSinceGrenadeReady = 0.0f;
        }
        if(throwingGrenade == true)
        {
            grenadeThrowTimeOffset -= Time.deltaTime;
            if(grenadeThrowTimeOffset <= 0.0f)
            {
                grenadeThrowTimeOffset = grenadeThrowDefaultTimeOffset;
                throwingGrenade = false;
                throwGrenade.Play();
            }
        }
    }
    void Meelee()
    {
        if (keyBoardManager.MeeleePressed() && !isMeeleeing)
        {
            isMeeleeing = true;
        }
        if (isMeeleeing)
        {
            meeleeTimeOffset -= Time.deltaTime;
            if (meeleeTimeOffset <= 0.0f)
            {
                meeleeTimeOffset = defaultMeeleeTimeOffset;
                isMeeleeing = false;
                meelee.Play();
            }
        }
    }
    private void RifleSounds()
    {
        if(keyBoardManager.ReloadPressed() && !isReloading)
        {
            isReloading = true;
        }
        if (isReloading)
        {
            rifleReloadTimeOffset -= Time.deltaTime;
            if (rifleReloadTimeOffset <= 0.0f)
            {
                rifleReloadTimeOffset = rifleDefaultReloadTimeOffset;
                isReloading = false;
                rifleReload.Play();
            }
        }

        if(keyBoardManager.ShootPressed() && !hasShot)
        {
            hasShot = true;
        }
        if(hasShot)
        {
            if(timeSinceLastShot == 0.0f)
            {
                rifleShoot.Play();

            }
            timeSinceLastShot += Time.deltaTime;
            if(timeSinceLastShot >= TimeBetweenShots)
            {
                timeSinceLastShot = 0.0f;
                hasShot = false;
            }
        }
    }
    private void PistolSounds()
    {

    }
    private void SniperSounds()
    {

    }
    private void HeavySounds()
    {

    }
}
