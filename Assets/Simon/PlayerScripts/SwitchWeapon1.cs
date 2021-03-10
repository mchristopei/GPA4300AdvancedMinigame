using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon1 : MonoBehaviour
{
    List<GameObject> weapons;
    [SerializeField] private int selectedWeapon = 0;
    public bool CanSwitch = false;
    private float switchTimer = 0.0f;
    private bool switchWeapon = false;

    void Awake()
    {
        PlayerInventory.WeaponsInInventoryList = new List<GameObject>();
    }
    void Start()
    {
        SelectWeapon();
        Debug.Log(PlayerInventory.WeaponsInInventoryList.Count);
    }

    void Update()
    {

        if (!CanSwitch)
        return;
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            
            if (selectedWeapon >= PlayerInventory.WeaponsInInventoryList.Count - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = PlayerInventory.WeaponsInInventoryList.Count - 1;
            else
                selectedWeapon--;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (GameObject gun in PlayerInventory.WeaponsInInventoryList)
        {
            if (i == selectedWeapon)
            {
                gun.gameObject.SetActive(true);
                gun.gameObject.tag = "Equipped";
            }
            else
            {
                gun.gameObject.SetActive(false);
                gun.gameObject.tag = "Unequipped";
            }
            i++;
        }
        SetAnimation();
    }
    void SetAnimation()
    {
        if(PlayerInventory.WeaponsInInventoryList[selectedWeapon].name == "Rifle")
        {
            KeyBoardManager.PistolActive = false;
            KeyBoardManager.HeavyActive = false;
            KeyBoardManager.SniperActive = false;
            KeyBoardManager.RifleActive = true;
        }
        else if(PlayerInventory.WeaponsInInventoryList[selectedWeapon].name == "Pistol")
        {
            KeyBoardManager.PistolActive = true;
            KeyBoardManager.HeavyActive = false;
            KeyBoardManager.SniperActive = false;
            KeyBoardManager.RifleActive = false;
        }
        else if (PlayerInventory.WeaponsInInventoryList[selectedWeapon].name == "Sniper")
        {
            KeyBoardManager.PistolActive = false;
            KeyBoardManager.HeavyActive = false;
            KeyBoardManager.SniperActive = true;
            KeyBoardManager.RifleActive = false;
        }
        else if (PlayerInventory.WeaponsInInventoryList[selectedWeapon].name == "Heavy")
        {
            KeyBoardManager.PistolActive = false;
            KeyBoardManager.HeavyActive = true;
            KeyBoardManager.SniperActive = false;
            KeyBoardManager.RifleActive = false;
        }
    }
}
