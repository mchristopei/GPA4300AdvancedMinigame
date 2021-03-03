using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMagazine: MonoBehaviour
{
    private int weaponCounter = 0;
    
    private void Update()
    {
        if(KeyBoardManager.SwitchWeaponPressed())
        {
            if(PlayerInventory.WeaponsInInventoryList.Count > 0)
            {
                if(PlayerInventory.WeaponsInInventoryList.Count == 1)
                {
                    weaponCounter = 0;
                    return;
                }
                if (weaponCounter < PlayerInventory.WeaponsInInventoryList.Count && PlayerInventory.WeaponsInInventoryList.Count > 1)
                {
                    weaponCounter += 1;
                }
                if (weaponCounter >= PlayerInventory.WeaponsInInventoryList.Count)
                {
                    weaponCounter = 1;
                }
            }
            else if(PlayerInventory.WeaponsInInventoryList.Count <= 0)
            {
                weaponCounter = -1;
            }
        }
    }
}
