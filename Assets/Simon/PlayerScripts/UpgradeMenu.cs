using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private bool upgradeLevel = false;
    private bool upgradingLevel = false;

    [SerializeField] private bool upgradeHealth = false;
    private bool upgradingHealth = false;

    [SerializeField] private bool upgradeDefense = false;
    private bool upgradingDefense = false;

    [SerializeField] private bool upgradeDamage = false;
    private bool upgradingDamage = false;

    [SerializeField] private bool upgradeRange = false;
    private bool upgradingRange = false;

    [SerializeField] private bool upgradeAmmoCapacity = false;
    private bool upgradingAmmoCapacity = false;

    [SerializeField] private bool upgradeMagazineCapacity = false;
    private bool upgradingMagazineCapacity = false;

    [SerializeField] private bool downgradeLevel = false;
    private bool downgradingLevel = false;

    [SerializeField] private bool downgradeHealth = false;
    private bool downgradingHealth = false;

    [SerializeField] private bool downgradeDefense = false;
    private bool downgradingDefense = false;

    [SerializeField] private bool downgradeDamage = false;
    private bool downgradingDamage = false;

    [SerializeField] private bool downgradeRange = false;
    private bool downgradingRange = false;

    [SerializeField] private bool downgradeAmmoCapacity = false;
    private bool downgradingAmmoCapacity = false;

    [SerializeField] private bool downgradeMagazineCapacity = false;
    private bool downgradingMagazineCapacity = false;

    [SerializeField] private float buttonLagTime = 0.25f;
    private float timeSinceLastClick;

    private int boolLimit = 0;
    private PlayerStats playerStats;
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void Update()
    {
        ModifyLevel();
        ButtonControl();
    }
    private void ButtonControl()
    {
        if (timeSinceLastClick < buttonLagTime && (upgradeLevel || downgradeLevel || upgradeHealth || downgradeHealth || upgradeDefense || downgradeDefense || upgradeAmmoCapacity || downgradeAmmoCapacity || upgradeMagazineCapacity || downgradeMagazineCapacity || upgradeDamage || downgradeDamage || upgradeRange || downgradeRange))
        {
            timeSinceLastClick += Time.deltaTime;
        }
        if (timeSinceLastClick >= buttonLagTime)
        {
            if (upgradeLevel)
            {
                upgradeLevel = false;
                upgradingLevel = false;
            }
            if (downgradeLevel)
            {
                downgradeLevel = false;
                downgradingLevel = false;
            }
            if (upgradeHealth)
            {
                upgradeHealth = false;
                upgradingHealth = false;
            }
            if (downgradeHealth)
            {
                downgradeHealth = false;
                downgradingHealth = false;
            }
            if (upgradeDefense)
            {
                upgradeDefense = false;
                upgradingDefense = false;
            }
            if (downgradeDefense)
            {
                downgradeDefense = false;
                downgradingDefense = false;
            }
            if (upgradeDamage)
            {
                upgradeDamage = false;
                upgradingDamage = false;
            }
            if (downgradeDamage)
            {
                downgradeDamage = false;
                downgradingDamage = false;
            }
            if (upgradeAmmoCapacity)
            {
                upgradeAmmoCapacity = false;
                upgradingAmmoCapacity = false;
            }
            if (downgradeAmmoCapacity)
            {
                downgradeAmmoCapacity = false;
                downgradingAmmoCapacity = false;
            }
            if (upgradeMagazineCapacity)
            {
                upgradeMagazineCapacity = false;
                upgradingMagazineCapacity = false;
            }
            if (downgradeMagazineCapacity)
            {
                downgradeMagazineCapacity = false;
                downgradingMagazineCapacity = false;
            }
            if (upgradeRange)
            {
                upgradeRange = false;
                upgradingRange = false;
            }
            if (downgradeRange)
            {
                downgradeRange = false;
                downgradingRange = false;
            }
            timeSinceLastClick = 0.0f;
            boolLimit = 0;
        }
    }
    private void ModifyLevel()
    {
        if (upgradeLevel)
        {
            if (boolLimit == 1 && !upgradingLevel)
            {
                upgradeLevel = false;
            }
            else if (boolLimit == 0)
            {
                if (timeSinceLastClick <= 0.0f)
                {
                    playerStats.RaiseLevel(PlayerStats.StatType.Level);
                    boolLimit += 1;
                    upgradingLevel = true;
                }
            }
        }
        if (downgradeLevel)
        {
            if (boolLimit == 1 && !downgradingLevel)
            {
                downgradeLevel = false;
            }
            else if(boolLimit == 0)
            {
                if (timeSinceLastClick <= 0.0f)
                {
                    playerStats.LowerLevel(PlayerStats.StatType.Level);
                    boolLimit += 1;
                    downgradingLevel = true;
                }
            }
        }
        if (upgradeDefense)
        {
            if (boolLimit == 1 && !upgradingDefense)
            {
                upgradeDefense = false;
            }
            else
            {
                if (timeSinceLastClick <= 0.0f)
                {
                    playerStats.RaiseLevel(PlayerStats.StatType.Defense);
                    boolLimit += 1;
                    upgradingDefense = true;
                }
            }
        }
        if (downgradeDefense)
        {
            if (boolLimit == 1 && !downgradingDefense)
            {
                downgradeDefense = false;
            }
            else
            {
                if(timeSinceLastClick <= 0.0f)
                {
                    playerStats.LowerLevel(PlayerStats.StatType.Defense);
                    boolLimit += 1;
                    downgradingDefense = true;
                }
            }
        }
        if (upgradeHealth)
        {
            if (boolLimit == 1 && !upgradingHealth)
            {
                upgradeHealth = false;
            }
            else
            {
                if (timeSinceLastClick <= 0.0f)
                {
                    playerStats.RaiseLevel(PlayerStats.StatType.Health);
                    boolLimit += 1;
                    upgradingHealth = true;
                }
            }
        }
        if (downgradeHealth)
        {
            if (boolLimit == 1 && !downgradingHealth)
            {
                downgradeHealth = false;
            }
            else
            {
                if (timeSinceLastClick <= 0.0f)
                {
                    playerStats.LowerLevel(PlayerStats.StatType.Health);
                    boolLimit += 1;
                    downgradingHealth = true;
                }
            }
        }
        if (upgradeDamage)
        {
            if (boolLimit == 1 && !upgradingDamage)
            {
                upgradeDamage = false;
            }
            else
            {
                if (timeSinceLastClick <= 0.0f)
                {
                    playerStats.RaiseLevel(PlayerStats.StatType.GunDamage);
                    boolLimit += 1;
                    upgradingDamage = true;
                }
            }
        }
        if (downgradeDamage)
        {
            if (boolLimit == 1 && !downgradingDamage)
            {
                downgradeDamage = false;
            }
            else
            {
                if (timeSinceLastClick <= 0.0f)
                {
                    playerStats.LowerLevel(PlayerStats.StatType.GunDamage);
                    boolLimit += 1;
                    downgradingDamage = true;
                }
            }
        }
        if (upgradeRange)
        {
            if (boolLimit == 1 && !upgradingRange)
            {
                upgradeRange = false;
            }
            else
            {
                if (timeSinceLastClick <= 0.0f)
                {
                    playerStats.RaiseLevel(PlayerStats.StatType.GunRange);
                    boolLimit += 1;
                    upgradingRange = true;
                }
            }
        }
        if (downgradeRange)
        {
            if (boolLimit == 1 && !downgradingRange)
            {
                downgradeRange = false;
            }
            else
            {
                if (timeSinceLastClick <= 0.0f)
                {
                    playerStats.LowerLevel(PlayerStats.StatType.GunRange);
                    boolLimit += 1;
                    downgradingRange = true;
                }
            }
        }
        if (upgradeAmmoCapacity)
        {
            if (boolLimit == 1 && !upgradingAmmoCapacity)
            {
                upgradeAmmoCapacity = false;
            }
            else
            {
                if (timeSinceLastClick <= 0.0f)
                {
                    playerStats.RaiseLevel(PlayerStats.StatType.AmmoCapacity);
                    boolLimit += 1;
                    upgradingAmmoCapacity = true;
                }
            }
        }
        if (downgradeAmmoCapacity)
        {
            if (boolLimit == 1 && !downgradeAmmoCapacity)
            {
                downgradeAmmoCapacity = false;
            }
            else
            {
                if (timeSinceLastClick <= 0.0f)
                {
                    playerStats.LowerLevel(PlayerStats.StatType.AmmoCapacity);
                    boolLimit += 1;
                    downgradingAmmoCapacity = true;
                }
            }
        }
        if (upgradeMagazineCapacity)
        {
            if (boolLimit == 1 && !upgradingMagazineCapacity)
            {
                upgradeMagazineCapacity = false;
            }
            else
            {
                if (timeSinceLastClick <= 0.0f)
                {
                    playerStats.RaiseLevel(PlayerStats.StatType.MagazineCapacity);
                    boolLimit += 1;
                    upgradingMagazineCapacity = true;
                }
            }
        }
        if (downgradeMagazineCapacity)
        {
            if (boolLimit == 1 && !downgradingMagazineCapacity)
            {
                downgradeMagazineCapacity = false;
            }
            else
            {
                if (timeSinceLastClick <= 0.0f)
                {
                    playerStats.LowerLevel(PlayerStats.StatType.MagazineCapacity);
                    boolLimit += 1;
                    downgradingMagazineCapacity = true;
                }
            }
        }
    }
}
