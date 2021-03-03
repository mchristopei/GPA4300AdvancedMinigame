using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public bool ApplyUpdates;

    [SerializeField] public int Level;
    [SerializeField] public float defense;
    [SerializeField] public float health;
    [SerializeField] public float JumpStrength;
    [SerializeField] public float GunDamageUpgradeAmount;
    [SerializeField] public float GunRangeUpgradeAmount;
    [SerializeField] public float ammoCapacityUpgradeAmount;
    [SerializeField] public float MagazineCapacityUpgradeAmount;
                     
    [SerializeField] public int healthUpgradeLevel;
    [SerializeField] public int defenseUpgradeLevel;
    [SerializeField] public int jumpLevel;
    [SerializeField] public int GunDamageLevel;
    [SerializeField] public int GunRangeLevel;
    [SerializeField] public int ammoCapacityLevel;
    [SerializeField] public int magazineCapacityLevel;
    private void Awake()
    {
        //PlayerSpecififcStats
        health = 100.0f + Level + healthUpgradeLevel * 10;
        defense = 5f + Level + defenseUpgradeLevel * 10;
        JumpStrength = 2f + jumpLevel * 0.25f;
        //WeaponStats
        GunDamageUpgradeAmount = 1.0f + GunDamageLevel * 0.2f + Level;
        GunRangeUpgradeAmount = 1.0f + GunRangeLevel * 0.2f + Level;
        ammoCapacityUpgradeAmount = 1.0f + ammoCapacityLevel * 0.25f + Level;
        MagazineCapacityUpgradeAmount = 1f + magazineCapacityLevel * 2.5f + Level;
    }
    private void Update()
    {
        if(ApplyUpdates)
        {
            health = 100.0f + Level + healthUpgradeLevel * 10;
            defense = 5f + Level + defenseUpgradeLevel * 10;
            JumpStrength = 2f + jumpLevel * 0.25f;
            GunDamageUpgradeAmount = GunDamageLevel * 5 + Level;
            GunRangeUpgradeAmount = 1.0f + GunRangeLevel * 0.2f + Level;
            ammoCapacityUpgradeAmount = 1.0f + ammoCapacityLevel * 0.25f + Level;
            MagazineCapacityUpgradeAmount = 1f + magazineCapacityLevel * 2.5f + Level;
        }
    }

}
