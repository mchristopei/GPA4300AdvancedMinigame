using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [SerializeField] private Text healthText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text defenseText;
    [SerializeField] private Text damageText;
    [SerializeField] private Text rangeText;
    [SerializeField] private Text ammoCapText;
    [SerializeField] private Text magCapText;

    [SerializeField] public float maxLevel = 10.0f;

    Dictionary<StatType, int> playerLevels;

    public event Action<StatType, int> LevelModified;

    private void Awake()
    {
        playerLevels = new Dictionary<StatType, int>();
        ResetStats();
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("GameOverScene");
            Cursor.lockState = CursorLockMode.None;
            Destroy(gameObject);

        }
        healthBar.value = health;

    }
    public void SetMaxHealth()
    {
        healthBar.maxValue = health;
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
        UpgradeUi();
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
        UpgradeUi();
        ResetStats();

        if (LevelModified != null)
            LevelModified.Invoke(type, playerLevels[type]);
    }
    private void UpgradeUi()
    {
        healthText.text = Convert.ToString(GetLevelFor(StatType.Health));
        levelText.text = Convert.ToString(GetLevelFor(StatType.Level));
        defenseText.text = Convert.ToString(GetLevelFor(StatType.Defense));
        damageText.text = Convert.ToString(GetLevelFor(StatType.GunDamage));
        rangeText.text = Convert.ToString(GetLevelFor(StatType.GunRange));
        ammoCapText.text = Convert.ToString(GetLevelFor(StatType.AmmoCapacity));
        magCapText.text = Convert.ToString(GetLevelFor(StatType.MagazineCapacity));
    }

}
