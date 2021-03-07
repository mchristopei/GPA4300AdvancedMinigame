using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenu : MonoBehaviour
{
    private int equippedPowerUp = 1;


    private int plusJumpItemCount = 3;
    private int plusDefenseItemCount = 3;
    private int plusDamageItemCount = 3;
    private float timeSinceItemUsed;
    [SerializeField] private float itemUpgradeTime = 5f;
    private PlayerStats playerStats;
    private int maxItemCount;
    private bool usingItem = false;

    private List<int> itemTypes;

    private void Start()
    {
        itemTypes = new List<int>();
        itemTypes.Add(plusDamageItemCount);
        itemTypes.Add(plusDefenseItemCount);
        itemTypes.Add(plusJumpItemCount);

        timeSinceItemUsed = 5f;
        playerStats = FindObjectOfType<PlayerStats>();
    }
    private void Update()
    {
        if(KeyBoardManager.switchItems() && !usingItem)
        {
            equippedPowerUp += 1;
            if(equippedPowerUp == 4)
            {
                equippedPowerUp = 1;
            }
        }
        if (KeyBoardManager.useItemKey() && timeSinceItemUsed == itemUpgradeTime)
        {
            if (equippedPowerUp == 1)
            {
                if (plusDamageItemCount >= 1)
                {
                    usingItem = true;
                    plusDamageItemCount -= 1;
                    playerStats.GunDamageUpgradeAmount += 1f;
                }
            }
            else if (equippedPowerUp == 2)
            {
                if(plusDefenseItemCount >= 1)
                {
                    usingItem = true;
                    plusDefenseItemCount -= 1;
                    playerStats.defense += 10;
                }
            }
            else if (equippedPowerUp == 3)
            {
                if (plusJumpItemCount >= 1)
                {
                    usingItem = true;
                    plusJumpItemCount -= 1;
                    playerStats.JumpStrength += 0.5f;
                }
            }
        }
        if(usingItem)
        {
            timeSinceItemUsed -= Time.deltaTime;
        }
        if(timeSinceItemUsed <= 0.0f && usingItem)
        {
            if (equippedPowerUp == 1)
            {
                playerStats.GunDamageUpgradeAmount -= 1;
            }
            else if (equippedPowerUp == 2)
            {
                playerStats.defense -= 10;
            }
            else if (equippedPowerUp == 3)
            {
                playerStats.JumpStrength -= 0.5f;
            }
            usingItem = false;
            timeSinceItemUsed = 5.0f;
        }
    }
}
