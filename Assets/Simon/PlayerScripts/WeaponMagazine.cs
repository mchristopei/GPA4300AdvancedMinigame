using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMagazine: MonoBehaviour
{
    private int weaponCounter = 0;

    private void Start()
    {
        KeyBoardManager.PistolActive = false;
        KeyBoardManager.HeavyActive = false;
        KeyBoardManager.SniperActive = false;
        KeyBoardManager.RifleActive = true;

        PlayerInventory.WeaponsInInventoryList[0].SetActive(true);
        PlayerInventory.WeaponsInInventoryList[1].SetActive(false);
        PlayerInventory.WeaponsInInventoryList[2].SetActive(false);
        PlayerInventory.WeaponsInInventoryList[3].SetActive(false);
    }
    
    private void Update()
    {
        if(KeyBoardManager.SwitchWeaponPressed())
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
                KeyBoardManager.RifleActive = false;
                KeyBoardManager.HeavyActive = false;
                KeyBoardManager.SniperActive = false;
                KeyBoardManager.PistolActive = true;
                break;
            case "Rifle":
                KeyBoardManager.PistolActive = false;
                KeyBoardManager.SniperActive = false;
                KeyBoardManager.HeavyActive = false;
                KeyBoardManager.RifleActive = true;
                break;
            case "Heavy":
                KeyBoardManager.PistolActive = false;
                KeyBoardManager.RifleActive = false;
                KeyBoardManager.SniperActive = false;
                KeyBoardManager.HeavyActive = true;
                break;
            case "Sniper":
                KeyBoardManager.PistolActive = false;
                KeyBoardManager.RifleActive = false;
                KeyBoardManager.HeavyActive = false;
                KeyBoardManager.SniperActive = true;
                break;
            default:
                Destroy(gameObject);
                break;
        }
    }
}
