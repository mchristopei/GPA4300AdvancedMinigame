using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    protected private AmmunitionControl ammunitionControl;

    new public Camera camera;
    public GameObject Crosshair;

    protected private KeyBoardManager keyBoardManager;

    [SerializeField] protected private float RegularFov = 60.0f;
    [SerializeField] protected private float AimFov = 140.0f;

    [SerializeField] protected private float regNearClippingPlane = 0.01f;
    [SerializeField] protected private float aimNearClippingPlane = 0.75f;

    [SerializeField] protected private float ammoLeftInMagazine = 0;
    [SerializeField] protected private float totalAmmoCount;
    [SerializeField] protected private float maxAmmoAmount = 0;
    [SerializeField] protected private float damage = 0.0f;
    [SerializeField] protected private float range = 0.0f;
    [SerializeField] protected private float magazineCapacity = 0;
    [SerializeField] protected private float timeBetweenShots = 0.0f;

    protected private float initMaxAmmoCount;
    protected private float initDamageAmaount;
    protected private float initRangeAmount;
    protected private float initMagazineCapacity;

    protected private bool isShooting = false;
    protected private float timer = 0.0f;
    protected private float shotTimer = 0.0f;

    protected private PlayerStats playerStats;
    protected private bool isAiming;
    protected private float aimTimer;

    protected private float ReloadTimer = 0.0f;

    //UI
    public Text currentMagazineAmmo;
    public Text currentAmmo;

    private void Awake()
    {
        
    }
    public void Start()
    {
        ammunitionControl = FindObjectOfType<AmmunitionControl>();
        keyBoardManager = FindObjectOfType<KeyBoardManager>();
        keyBoardManager.isReloading = false;
        PlayerInventory.WeaponsInInventoryList.Add(this.gameObject);
        playerStats = FindObjectOfType<PlayerStats>();
        playerStats.LevelModified += OnLevelRaised;
        ConfigInitValues();

        initMaxAmmoCount = maxAmmoAmount;
        initDamageAmaount = damage;
        initRangeAmount = range;
        initMagazineCapacity = magazineCapacity;
        statsUpgradeManager();
        SetAmmoOnStart();
        currentMagazineAmmo.text = Convert.ToString(ammoLeftInMagazine);
        currentAmmo.text = Convert.ToString(totalAmmoCount);
    }
    public virtual void SetAmmoOnStart()
    {
       
    }

    public virtual void ConfigInitValues()
    { 
        
    }
    public virtual void Audio()
    {

    }
    public void OnLevelRaised(PlayerStats.StatType type, int level)
    {
        statsUpgradeManager();
    }

    public void Update()
    {
        setAmmoControlStats();

        if (ammoLeftInMagazine == 0)
        {
            keyBoardManager.outOfAmmo = true;
        }
        if (!keyBoardManager.outOfAmmo && keyBoardManager.outOfAmmo == true)
        {
            keyBoardManager.outOfAmmo = false;
        }
            Aim();
            Shoot();
    }
    public void Aim()
    {
        if (keyBoardManager.AimPressed())
        {
            isAiming = true;
            aimTimer += Time.deltaTime;

            if (aimTimer >= 0.25f)
            {
                camera.fieldOfView = AimFov;
                camera.nearClipPlane = aimNearClippingPlane;
                Crosshair.gameObject.SetActive(true);
            }
        }
        else
        {
            camera.fieldOfView = RegularFov;
            camera.nearClipPlane = regNearClippingPlane;
            Crosshair.gameObject.SetActive(false);
            isAiming = false;
            aimTimer = 0.0f;
        }
    }
    public void statsUpgradeManager()
    {
        damage = initDamageAmaount * (playerStats.GunDamageUpgradeAmount);
        range = initRangeAmount * playerStats.GunRangeUpgradeAmount;
        maxAmmoAmount = initMaxAmmoCount * playerStats.ammoCapacityUpgradeAmount;
        magazineCapacity = initMagazineCapacity * playerStats.MagazineCapacityUpgradeAmount;
       
    }

    public virtual void GetInput()
    {

    }
    public void Shoot()
    {
        GetInput();
        if (isShooting)
        {
            if(!keyBoardManager.isReloading)
            {
                if (shotTimer == 0.0f && ammoLeftInMagazine > 0)
                {
                    ShootRayCast();
                    ammoLeftInMagazine -= 1;
                    currentMagazineAmmo.text = Convert.ToString(ammoLeftInMagazine);
                    currentAmmo.text = Convert.ToString(totalAmmoCount);
                }
            }

            shotTimer += Time.deltaTime;

            if (shotTimer >= timeBetweenShots)
            {
                isShooting = false;
            }
        }
        if (!isShooting)
        {
            shotTimer = 0.0f;
        }
        SetTotalAmmoCountAndReloadAmount();
    }
    public void ShootRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position + camera.transform.forward.normalized, camera.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            Debug.Log(hit.transform.name);

            if (target != null)
            {
                if (target is IDamagable)
                {
                    if (hit.distance > range * 0.75f)
                    {

                        target.health -= (damage * 0.25f);
                    }
                    else if (hit.distance < (range * 0.75) && hit.distance > range * 0.5f)
                    {
                        target.health -= (damage * 0.5f);
                    }
                    else if (hit.distance > 0.1f && hit.distance < range * 0.25f)
                    {
                        target.health -= (damage);
                    }

                    // Rigidbody rb = target.transform.GetComponent<Rigidbody>();
                    // if (rb != null)
                    // {
                    //     rb.AddExplosionForce(710f, hit.point, 0.5f);
                    // }

                    //GameObject ImpactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    //Destroy(ImpactGO, 1f);
                }
            }
            else if (hit.transform.name != "Player")
            {
                //GameObject ImpactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                //Destroy(ImpactGO, 1f);
            }
        }
    }
    public void SetTotalAmmoCountAndReloadAmount()
    {
        if (keyBoardManager.ReloadPressed())
        {
            keyBoardManager.isReloading = true;
            if (totalAmmoCount > magazineCapacity && ammoLeftInMagazine < magazineCapacity && totalAmmoCount >= (magazineCapacity - ammoLeftInMagazine))
            {
                totalAmmoCount -= (magazineCapacity - ammoLeftInMagazine);
                ammoLeftInMagazine += (magazineCapacity - ammoLeftInMagazine);
            }
            else if (totalAmmoCount < magazineCapacity && totalAmmoCount < (magazineCapacity - ammoLeftInMagazine))
            {
                ammoLeftInMagazine += totalAmmoCount;
                totalAmmoCount = 0;
            }
            currentMagazineAmmo.text = Convert.ToString(ammoLeftInMagazine);
            currentAmmo.text = Convert.ToString(totalAmmoCount);
        }
        if(keyBoardManager.isReloading)
        {
            ReloadTimer += Time.deltaTime;
            if(ReloadTimer >=3.75f)
            {
                keyBoardManager.isReloading = false;
                ReloadTimer = 0.0f;
            }
        }

    }
    public virtual void setAmmoControlStats()
    {

    }
}
