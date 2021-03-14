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

		InventoryController.WeaponsInInventory[0].SetActive(true);
		InventoryController.WeaponsInInventory[1].SetActive(false);
		InventoryController.WeaponsInInventory[2].SetActive(false);
		InventoryController.WeaponsInInventory[3].SetActive(false);
    }
    
    private void Update()
    {
        if(keyBoardManager.SwitchWeaponPressed())
        {
            Debug.Log(InventoryController.WeaponsInInventory.Count);
			InventoryController.WeaponsInInventory[weaponCounter].SetActive(false);
                weaponCounter += 1;
                if (weaponCounter >= InventoryController.WeaponsInInventory.Count)
                {
                    weaponCounter = 0;
                }
                Debug.Log(weaponCounter);
			//else if(PlayerInventory.WeaponsInInventoryList.Count <= 0)
			//{
			//    weaponCounter = -1;
			//}
			InventoryController.WeaponsInInventory[weaponCounter].SetActive(true);
            SetWeapon();
        }
    }
    void SetWeapon()
    {
        switch (InventoryController.WeaponsInInventory[weaponCounter].name)
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
