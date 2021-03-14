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

		InventoryController.WeaponsInInventory[0].SetActive(true);
		InventoryController.WeaponsInInventory[1].SetActive(false);
		InventoryController.WeaponsInInventory[2].SetActive(false);
		InventoryController.WeaponsInInventory[3].SetActive(false);
    }
    
    private void Update()
    {
        if(KeyBoardManager.SwitchWeaponPressed())
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
