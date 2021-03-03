using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private bool upgradeLevel = false;
    [SerializeField] private bool upgradeHealth = false;
    [SerializeField] private bool upgradeDefense = false;
    [SerializeField] private bool upgradeDamage = false;
    [SerializeField] private bool upgradeRange = false;
    [SerializeField] private bool upgradeAmmoCapacity = false;
    [SerializeField] private bool upgradeMagazineCapacity = false;

    private PlayerStats playerStats;

    private int maxUpgradeLevel = 10;
    void Start()
    {

        playerStats = FindObjectOfType<PlayerStats>();

        playerStats.Level = 0;
        playerStats.defenseUpgradeLevel = 1;
        playerStats.healthUpgradeLevel = 1;
        playerStats.GunDamageLevel = 1;
        playerStats.GunRangeLevel = 0;
        playerStats.ammoCapacityLevel = 0;
        playerStats.magazineCapacityLevel = 0;
        playerStats.ApplyUpdates = true;
    }

    void Update()
    {
        if(upgradeLevel == true)
        {
            playerStats.Level += 1;
            LimitMaxLevel(playerStats.Level);
        }
        if (upgradeDefense == true)
        {
            playerStats.defenseUpgradeLevel += 1;
            LimitMaxLevel(playerStats.defenseUpgradeLevel);
        }
        if (upgradeHealth == true)
        {
            playerStats.healthUpgradeLevel += 1;
            LimitMaxLevel(playerStats.healthUpgradeLevel);
        }
        if (upgradeDamage == true)
        {
            playerStats.GunDamageLevel += 1;
            LimitMaxLevel(playerStats.GunDamageLevel);
        }
        if (upgradeRange == true)
        {
            playerStats.GunRangeLevel += 1;
            LimitMaxLevel(playerStats.GunRangeLevel);
        }
        if (upgradeAmmoCapacity == true)
        {
            playerStats.ammoCapacityLevel += 1;
            LimitMaxLevel(playerStats.ammoCapacityLevel);
        }
        if (upgradeMagazineCapacity == true)
        {
            playerStats.magazineCapacityLevel += 1;
            LimitMaxLevel(playerStats.magazineCapacityLevel);
        }
        if(upgradeLevel || upgradeHealth || upgradeDefense|| upgradeAmmoCapacity || upgradeMagazineCapacity || upgradeDamage || upgradeRange)
        {
            playerStats.ApplyUpdates = true;
            upgradeLevel = false;
            upgradeHealth = false;
            upgradeDefense = false;
            upgradeAmmoCapacity = false;
            upgradeMagazineCapacity = false;
            upgradeDamage = false;
            upgradeRange = false;
        }
    }
    void LimitMaxLevel(int level)
    {
        if (level > maxUpgradeLevel)
        {
            level = maxUpgradeLevel;
        }
    }
}
