using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMagazine: MonoBehaviour
{
    private int weaponCounter = 0;
    private KeyBoardManager keyBoardManager;
    private void Start()
    {
        keyBoardManager = FindObjectOfType<KeyBoardManager>();
        keyBoardManager.PistolActive = false;
        keyBoardManager.HeavyActive = false;
        keyBoardManager.SniperActive = false;
        keyBoardManager.RifleActive = true;

        PlayerInventory.WeaponsInInventoryList[0].SetActive(true);
        PlayerInventory.WeaponsInInventoryList[1].SetActive(false);
        PlayerInventory.WeaponsInInventoryList[2].SetActive(false);
        PlayerInventory.WeaponsInInventoryList[3].SetActive(false);
    }
    
    private void Update()
    {
        if(keyBoardManager.SwitchWeaponPressed())
        {
            Debug.Log(PlayerInventory.WeaponsInInventoryList.Count);
                PlayerInventory.WeaponsInInventoryList[weaponCounter].SetActive(false);
                weaponCounter += 1;
                if (weaponCounter >= PlayerInventory.WeaponsInInventoryList.Count)
                {
                    weaponCounter = 0;
                }
                Debug.Log(weaponCounter);
            //else if(PlayerInventory.WeaponsInInventoryList.Count <= 0)
            //{
            //    weaponCounter = -1;
            //}
            PlayerInventory.WeaponsInInventoryList[weaponCounter].SetActive(true);
            SetWeapon();
        }
    }
    void SetWeapon()
    {
        switch (PlayerInventory.WeaponsInInventoryList[weaponCounter].name)
        {
            case "Pistol":
                keyBoardManager.RifleActive = false;
                keyBoardManager.HeavyActive = false;
                keyBoardManager.SniperActive = false;
                keyBoardManager.PistolActive = true;
                break;
            case "Rifle":
                keyBoardManager.PistolActive = false;
                keyBoardManager.SniperActive = false;
                keyBoardManager.HeavyActive = false;
                keyBoardManager.RifleActive = true;
                break;
            case "Heavy":
                keyBoardManager.PistolActive = false;
                keyBoardManager.RifleActive = false;
                keyBoardManager.SniperActive = false;
                keyBoardManager.HeavyActive = true;
                break;
            case "Sniper":
                keyBoardManager.PistolActive = false;
                keyBoardManager.RifleActive = false;
                keyBoardManager.HeavyActive = false;
                keyBoardManager.SniperActive = true;
                break;
            default:
                Destroy(gameObject);
                break;
        }
    }
}
