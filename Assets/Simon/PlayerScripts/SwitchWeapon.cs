using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] private GameObject riflePlayer;
    [SerializeField] private GameObject pistolPlayer;
    private List<GameObject> weaponList;
    [SerializeField] private Animator gunAnimator;

    bool isSwitchingWeapons;
    [SerializeField] private KeyCode switchWeaponKey = KeyCode.Y;

    private int NextWeapon = 0;
    private int activeWeapon = 0;
    void Start()
    {
        weaponList = new List<GameObject>();
        weaponList.Add(riflePlayer);
        weaponList.Add(pistolPlayer);
        weaponList[activeWeapon].SetActive(true);
        gunAnimator = weaponList[activeWeapon].GetComponentInChildren<Animator>();
    }

    void Update()
    {
        isSwitchingWeapons = Input.GetKeyDown(switchWeaponKey);
        if(isSwitchingWeapons)
        {
            gunAnimator.SetBool("SwitchWeapon", true);
            gunAnimator.SetBool("SwitchWeapon", false);
            NextWeapon += activeWeapon + 1;
            if(NextWeapon >= weaponList.Count)
            {
                NextWeapon = 0;
                weaponList[weaponList.Count - 1].SetActive(false);
                weaponList[NextWeapon].SetActive(true);
            }
            else
            {
                weaponList[activeWeapon].SetActive(false);
                weaponList[NextWeapon].SetActive(true);
            }
            activeWeapon = NextWeapon;
            gunAnimator = weaponList[activeWeapon].GetComponentInChildren<Animator>();
        }
    }
}
