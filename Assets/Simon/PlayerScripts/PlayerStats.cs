using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] int level;
    [SerializeField] public float defense;
    [SerializeField] public float health;
    [SerializeField] public float JumpStrength;
    [SerializeField] public float GunDamageUpgradeAmount;
    [SerializeField] public float GunRangeUpgradeAmount;
    [SerializeField] public float ammoCapacityUpgradeAmount;
    [SerializeField] public float MagazineCapacityUpgradeAmount;

    Dictionary<StatType, int> playerLevels;

    public event Action<StatType, int> LevelRaised;

    private void Awake()
    {
        playerLevels = new Dictionary<StatType, int>();
    }

    private void ResetStats()
    {
        health = 100.0f + level + GetLevelFor(StatType.Health) * 10;
        defense = 5f + level + GetLevelFor(StatType.Defense) * 10;
        JumpStrength = 2f + GetLevelFor(StatType.Jump) * 0.25f;
        GunDamageUpgradeAmount = GetLevelFor(StatType.GunDamage);
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
            playerLevels[type] += 1;
        }
        else
        {
            playerLevels.Add(type, 1);
        }

        ResetStats();

        if (LevelRaised != null)
            LevelRaised.Invoke(type, playerLevels[type]);
    }

}
