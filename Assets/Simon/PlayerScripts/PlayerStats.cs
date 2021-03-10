using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public enum StatType
    {
        None,
        Level,
        Health,
        Defense,
        Jump,
        GunDamage,
        GunRange,
        AmmoCapacity,
        MagazineCapacity
    }
    [SerializeField] private Slider healthBar;
    [SerializeField] int level;
    [SerializeField] public float defense;
    [SerializeField] public float health;
    [SerializeField] public float JumpStrength;
    [SerializeField] public float GunDamageUpgradeAmount;
    [SerializeField] public float GunRangeUpgradeAmount;
    [SerializeField] public float ammoCapacityUpgradeAmount;
    [SerializeField] public float MagazineCapacityUpgradeAmount;

    [SerializeField] public float maxLevel = 10.0f;

    Dictionary<StatType, int> playerLevels;

    public event Action<StatType, int> LevelModified;

    private void Awake()
    {
        playerLevels = new Dictionary<StatType, int>();
        ResetStats();
    }
    private void ResetStats()
    {
        health = 100.0f + level + GetLevelFor(StatType.Health) * 10;
        defense = 5f + level + GetLevelFor(StatType.Defense) * 10;
        JumpStrength = 2f + GetLevelFor(StatType.Jump) * 0.25f;
        GunDamageUpgradeAmount = 1f + GetLevelFor(StatType.GunDamage) * 0.25f;
        GunRangeUpgradeAmount = 1f + GetLevelFor(StatType.GunRange) * 0.25f;
        ammoCapacityUpgradeAmount = 1f + GetLevelFor(StatType.AmmoCapacity) * 0.25f;
        MagazineCapacityUpgradeAmount = 1f + GetLevelFor(StatType.MagazineCapacity) * 0.25f;
    }

    private int GetLevelFor(StatType type)
    {
        if (playerLevels.ContainsKey(type))
        {
            return playerLevels[type];
        }
        else
        {
            return 0;
        }
    }

    public void RaiseLevel(StatType type)
    {
        if (playerLevels.ContainsKey(type))
        {
            if(playerLevels[type] <= maxLevel)
            {
                playerLevels[type] += 1;
            }
        }
        else
        {
            playerLevels.Add(type, 1);
        }

        ResetStats();

        if (LevelModified != null)
            LevelModified.Invoke(type, playerLevels[type]);
    }
    public void LowerLevel(StatType type)
    {
        if (playerLevels.ContainsKey(type))
        {
            if(playerLevels[type] > 0)
            {
                playerLevels[type] -= 1;
            }
        }
        else
        {
            playerLevels.Add(type, 1);
        }

        ResetStats();

        if (LevelModified != null)
            LevelModified.Invoke(type, playerLevels[type]);
    }

}
