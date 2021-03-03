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
    }

    void Update()
    {
        if(upgradeLevel == true)
        {
            playerStats.RaiseLevel(PlayerStats.StatType.Level);
        }
        if (upgradeDefense == true)
        {
            playerStats.RaiseLevel(PlayerStats.StatType.Defense);
        }
        if (upgradeHealth == true)
        {
            playerStats.RaiseLevel(PlayerStats.StatType.Health);
        }
        if (upgradeDamage == true)
        {
            playerStats.RaiseLevel(PlayerStats.StatType.GunDamage);
        }
        if(upgradeLevel || upgradeHealth || upgradeDefense|| upgradeAmmoCapacity || upgradeMagazineCapacity || upgradeDamage || upgradeRange)
        {
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
