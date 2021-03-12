using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon1 : MonoBehaviour
{
    [SerializeField] private GameObject selectedWeapon;

    public bool CanSwitch = false;
    private float switchTimer = 0.0f;
    private bool switchingWeapon = false;
    private KeyBoardManager keyBoardManager;
    void Awake()
    {
        PlayerInventory.WeaponsInInventoryList = new List<GameObject>();
    }
    void Start()
    {
        keyBoardManager = FindObjectOfType<KeyBoardManager>();
        SelectWeapon();
        Debug.Log(PlayerInventory.WeaponsInInventoryList.Count);
    }

    void Update()
    {

        if (!CanSwitch)
        return;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            CanSwitch = false;
            StartCoroutine(SwitchWeapon(1));
        }
        
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            CanSwitch = false;
            StartCoroutine(SwitchWeapon(-1));
        }
    } 
    IEnumerator SwitchWeapon(int number)
    {
        GameObject lastWeapon = selectedWeapon;
        int i = PlayerInventory.WeaponsInInventoryList.IndexOf(selectedWeapon);
        i += number;
        if(i >= PlayerInventory.WeaponsInInventoryList.Count)
        {
            i = 0;
        }
        if(i < 0)
        {
            i = PlayerInventory.WeaponsInInventoryList.Count - 1;
        }
        selectedWeapon = PlayerInventory.WeaponsInInventoryList[i];

        SetAnimation();
        yield return new WaitForSeconds(0.5f);

        lastWeapon.SetActive(false);
        lastWeapon.tag = "Unequipped";

        selectedWeapon.SetActive(true);
        selectedWeapon.tag = "Equipped";

        yield return new WaitForSeconds(0.5f);

        CanSwitch = true;
    }
    void SelectWeapon()
    {
        foreach (GameObject gun in PlayerInventory.WeaponsInInventoryList)
        {

                if (gun == selectedWeapon)
                {
                    gun.SetActive(true);
                    gun.tag = "Equipped";
                }
                else
                {
                    gun.SetActive(false);
                    gun.tag = "Unequipped";
                }
        }
        
        SetAnimation();
    }
    void SetAnimation()
    {
        if(selectedWeapon.TryGetComponent<Rifle>(out Rifle rifle))
        {
            keyBoardManager.PistolActive = false;
            keyBoardManager.HeavyActive = false;
            keyBoardManager.SniperActive = false;
            keyBoardManager.RifleActive = true;
        }
        else if(selectedWeapon.TryGetComponent<Pistol>(out Pistol pistol))
        {
            keyBoardManager.PistolActive = true;
            keyBoardManager.HeavyActive = false;
            keyBoardManager.SniperActive = false;
            keyBoardManager.RifleActive = false;
        }
        else if (selectedWeapon.TryGetComponent<Sniper>(out Sniper sniper))
        {
            keyBoardManager.PistolActive = false;
            keyBoardManager.HeavyActive = false;
            keyBoardManager.SniperActive = true;
            keyBoardManager.RifleActive = false;
        }
        else if (selectedWeapon.TryGetComponent<ShotGun>(out ShotGun shotGun))
        {
            keyBoardManager.PistolActive = false;
            keyBoardManager.HeavyActive = true;
            keyBoardManager.SniperActive = false;
            keyBoardManager.RifleActive = false;
        }
    }
}
