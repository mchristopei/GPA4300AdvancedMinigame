using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour
{
    private int equippedPowerUp = 1;
    private KeyBoardManager keyBoardManager;

    [SerializeField] protected private int plusJumpItemCount = 3;
    [SerializeField] protected private int plusDefenseItemCount = 3;
    [SerializeField] protected private int plusDamageItemCount = 3;
    private float timeSinceItemUsed;
    [SerializeField] private float itemUpgradeTime = 5f;
    private PlayerStats playerStats;
    private int maxItemCount;
    private bool usingItem = false;

    private List<int> itemTypes;

    [SerializeField] private GameObject plusJumpItem;
    [SerializeField] private GameObject plusDefenseItem;
    [SerializeField] private GameObject plusDamageItem;
    [SerializeField] private SpriteRenderer uiCircle;
    [SerializeField] private Text potionCount;
    [SerializeField] private Text equippedItem;
    private void Start()
    {
        keyBoardManager = FindObjectOfType<KeyBoardManager>();
        itemTypes = new List<int>();
        itemTypes.Add(plusDamageItemCount);
        itemTypes.Add(plusDefenseItemCount);
        itemTypes.Add(plusJumpItemCount);

        timeSinceItemUsed = 5f;
        playerStats = FindObjectOfType<PlayerStats>();

        equippedPowerUp = 1;
        plusDamageItem.SetActive(true);
        plusDefenseItem.SetActive(false);
        plusJumpItem.SetActive(false);
        potionCount.text = Convert.ToString(plusDamageItemCount);
    }
    private void Update()
    {
        if(!usingItem)
        {
            uiCircle.transform.Rotate(Vector3.forward * Time.deltaTime * 20f);
            uiCircle.color = Color.red;
        }
        else if(usingItem)
        {
            uiCircle.transform.Rotate(Vector3.forward * Time.deltaTime * 80f);
            uiCircle.color = Color.green;
        }
        if(keyBoardManager.switchItems() && !usingItem)
        {
            equippedPowerUp += 1;
            if(equippedPowerUp == 1)
            {
                plusDamageItem.SetActive(true);
                plusDefenseItem.SetActive(false);
                plusJumpItem.SetActive(false);
                potionCount.text = Convert.ToString(plusDamageItemCount);
                equippedItem.text = "PlusDamageBoost";
            }
            else if(equippedPowerUp == 2)
            {
                plusDamageItem.SetActive(false);
                plusDefenseItem.SetActive(true);
                plusJumpItem.SetActive(false);
                potionCount.text = Convert.ToString(plusDefenseItemCount);   
                equippedItem.text = "PlusDefenseBoost";
            }
            else if(equippedPowerUp == 3)
            {
                plusDamageItem.SetActive(false);
                plusDefenseItem.SetActive(false);
                plusJumpItem.SetActive(true);
                potionCount.text = Convert.ToString(plusJumpItemCount);   
                equippedItem.text = "PlusJumpBoost";
            }
            else if(equippedPowerUp == 4)
            {
                equippedPowerUp = 1; 
                plusDamageItem.SetActive(true);
                plusDefenseItem.SetActive(false);
                plusJumpItem.SetActive(false);
                potionCount.text = Convert.ToString(plusDamageItemCount);

            }
        }
        if (keyBoardManager.useItemKey() && timeSinceItemUsed == itemUpgradeTime)
        {
            if (equippedPowerUp == 1)
            {
                if (plusDamageItemCount >= 1)
                {
                    usingItem = true;
                    plusDamageItemCount -= 1;
                    potionCount.text = Convert.ToString(plusDamageItemCount);   
                    playerStats.GunDamageUpgradeAmount += 1f;
                }
            }
            else if (equippedPowerUp == 2)
            {
                if(plusDefenseItemCount >= 1)
                {
                    usingItem = true;
                    plusDefenseItemCount -= 1;
                    potionCount.text = Convert.ToString(plusDefenseItemCount);   
                    playerStats.defense += 10;
                }
            }
            else if (equippedPowerUp == 3)
            {
                if (plusJumpItemCount >= 1)
                {
                    usingItem = true;
                    plusJumpItemCount -= 1;
                    potionCount.text = Convert.ToString(plusJumpItemCount);   
                    playerStats.JumpStrength += 2f;
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
                playerStats.JumpStrength -= 2f;
            }
            usingItem = false;
            timeSinceItemUsed = 5.0f;
        }
    }
}
