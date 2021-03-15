using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public bool isGrounded = true;
    private bool hasShot = false;

    //RifleSpecific
    [SerializeField] private AudioSource rifleShoot;
    [SerializeField] private float TimeBetweenShots = 0.1f;
    private float timeSinceLastShot = 0.0f;

    [SerializeField] private AudioSource rifleReload;
    [SerializeField] private float rifleReloadTimeOffset = 0.25f;
    private float rifleDefaultReloadTimeOffset;
    private bool isReloading = false;



    [SerializeField] private AudioSource meelee;
    [SerializeField] private float meeleeTimeOffset = 0.5f;
    private float defaultMeeleeTimeOffset;
    private bool isMeeleeing = false;

    [SerializeField] private AudioSource grabGrenade;
    [SerializeField] private AudioSource throwGrenade;
    [SerializeField] private float grenadeThrowTimeOffset = 0.5f;
    private float timeSinceGrenadeReady = 0.0f;
    private float grenadeThrowDefaultTimeOffset;
    private bool throwingGrenade = false;
    private bool grenadeReady = false;

    [SerializeField] private AudioSource Walk;
    private bool isWlaking = false;
    [SerializeField] private AudioSource Run;
    private bool isRunning = false;
    private KeyBoardManager keyBoardManager;

    [SerializeField] private AudioSource showLove;
    private float showLoveTimeOffset = 1.5f;
    private float defaultShowLoveTimeOffset;
    private bool isShowingLove;

    [SerializeField] private AudioSource ScopeIn;
    [SerializeField] private AudioSource ScopeOut;
    private bool scopeActive = false;
    void Start()
    {
        keyBoardManager = FindObjectOfType<KeyBoardManager>();
        defaultMeeleeTimeOffset = meeleeTimeOffset;
        rifleDefaultReloadTimeOffset = rifleReloadTimeOffset;


        grenadeThrowDefaultTimeOffset = grenadeThrowTimeOffset;
        defaultShowLoveTimeOffset = showLoveTimeOffset;
    }

    void Update()
    {
        GeneralSounds();
        RifleSounds();
    }
    void ScopeSounds()
    {
        if(keyBoardManager.AimPressed() && !scopeActive)
        {
            scopeActive = true;
            ScopeIn.Play();
        }
        if(!keyBoardManager.AimPressed() && scopeActive)
        {
            ScopeIn.Stop();
            ScopeOut.Play();
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
    void ShowLove()
    {
        if(keyBoardManager.ShowLovePressed() && !isShowingLove)
        {
            isShowingLove = true;
        }
        if(isShowingLove)
        {
            showLoveTimeOffset -= Time.deltaTime;
            if(showLoveTimeOffset <= 0.0f)
            {
                showLove.Play();
                isShowingLove = false;
                showLoveTimeOffset = defaultShowLoveTimeOffset;
            }
        }
    }
    private void GeneralSounds()
    {
        Meelee();
        Grenade();
        FootSteps();
        ShowLove();
        ScopeSounds();
    }
    void FootSteps()
    {
        if (isGrounded)
        {
            if (keyBoardManager.IsWalking() && !isWlaking)
            {
                Walk.Play();
                isWlaking = true;
            }
            if ((!keyBoardManager.IsWalking() && isWlaking))
            {
                Walk.Stop();
                isWlaking = false;
            }
            if (keyBoardManager.IsRunning() && !isRunning)
            {
                Run.Play();
                isRunning = true;
            }
            if ((!keyBoardManager.IsRunning() && isRunning))
            {
                Run.Stop();
                isRunning = false;
            }


        }
        else if(!isGrounded)
        {
            if(isWlaking)
            {
                Walk.Stop();
                isWlaking = false;
            }
            if(isRunning)
            {
                Run.Stop();
                isRunning = false;
            }
        }
        
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


    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Ground"))
        {
            isGrounded = false;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Ground"))
        {
            isGrounded = true;
        }
    }
}
