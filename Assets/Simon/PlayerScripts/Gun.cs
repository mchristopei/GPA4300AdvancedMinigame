﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    [SerializeField] new private Camera camera;

    [SerializeField] private float ammoLeftInMagazine = 0;
    [SerializeField] private float totalAmmoCount;
    [SerializeField] private float maxAmmoAmount = 0;
    [SerializeField] private float damage = 0.0f;
    [SerializeField] private float range = 0.0f;
    [SerializeField] private float magazineCapacity = 0;
    [SerializeField] private float timeBetweenShots = 0.0f;

    private float initMaxAmmoCount;
    private float initDamageAmaount;
    private float initRangeAmount;
    private float initMagazineCapacity;

    private bool isShooting = false;
    private float timer = 0.0f;

    private PlayerStats playerStats;
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();

        switch (gameObject.name)
        {
            case "Pistol":
                damage = 20f;
                range = 50f;
                maxAmmoAmount = 50;
                magazineCapacity = 10;
                timeBetweenShots = 1f;
                break;
            case "Rifle":
                damage = 10f;
                range = 100f;
                maxAmmoAmount = 200;
                magazineCapacity = 50;
                timeBetweenShots = 0.25f;
                break;
            case "Shotgun":
                damage = 30f;
                range = 30f;
                maxAmmoAmount = 50;
                magazineCapacity = 5;
                timeBetweenShots = 0.5f;
                break;
            case "Sniper":
                damage = 30f;
                range = 250f;
                maxAmmoAmount = 60;
                magazineCapacity = 8;
                timeBetweenShots = 2f;
                break;
            default:
                Destroy(gameObject);
                break;
        }
        PlayerInventory.WeaponsInInventoryList.Add(this.gameObject);

        initMaxAmmoCount = maxAmmoAmount;
        initDamageAmaount = damage;
        initRangeAmount = range;
        initMagazineCapacity = magazineCapacity;
        statsUpgradeManager();
    }
    private void Update()
    {
        Shoot();
        if (playerStats.ApplyUpdates == true)
        {
            statsUpgradeManager();
            playerStats.ApplyUpdates = false;
        }
    }
    private void statsUpgradeManager()
    {
        damage = initDamageAmaount * (playerStats.GunDamageUpgradeAmount);
        range = initRangeAmount * playerStats.GunRangeUpgradeAmount;
        maxAmmoAmount += initMaxAmmoCount * playerStats.ammoCapacityUpgradeAmount;
        magazineCapacity += initMagazineCapacity * playerStats.MagazineCapacityUpgradeAmount;

        totalAmmoCount = maxAmmoAmount;
        ammoLeftInMagazine = magazineCapacity;
    }
    private void Shoot()
    {
        if (KeyBoardManager.ShootPressed() && !isShooting)
        {
            isShooting = true;
        }

        if (isShooting && ammoLeftInMagazine >= 1)
        {
            timer += Time.deltaTime;
        }

        if (timer > timeBetweenShots)
        {
            ammoLeftInMagazine -= 1;
            timer = 0.0f;
            isShooting = false;
        }
        SetTotalAmmoCountAndReloadAmount();
        ShootRayCast();
    }
    void ShootRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position + camera.transform.forward.normalized, camera.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
           // Debug.Log(hit.transform.name);

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
        if (KeyBoardManager.ReloadPressed())
        {
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
        }
    }
}

