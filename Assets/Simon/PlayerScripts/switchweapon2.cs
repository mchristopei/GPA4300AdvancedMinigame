using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchweapon2 : MonoBehaviour
{
	List<GameObject> weapons;
	[SerializeField] private int selectedWeapon = 0;
	public bool CanSwitch = false;
	private float switchTimer = 0.0f;
	private bool switchWeapon = false;

	void Awake()
	{
		InventoryController.WeaponsInInventory = new List<GameObject>();
	}
	void Start()
	{
		SelectWeapon();
		Debug.Log(InventoryController.WeaponsInInventory.Count);
	}

	void Update()
	{
		if (!CanSwitch)
			return;

		int previousSelectedWeapon = selectedWeapon;

		if (Input.GetAxis("Mouse ScrollWheel") > 0f)
		{

			if (selectedWeapon >= InventoryController.WeaponsInInventory.Count - 1)
				selectedWeapon = 0;
			else
				selectedWeapon++;
		}

		if (Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			if (selectedWeapon <= 0)
				selectedWeapon = InventoryController.WeaponsInInventory.Count - 1;
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
		foreach (GameObject gun in InventoryController.WeaponsInInventory)
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
		if (InventoryController.WeaponsInInventory[selectedWeapon].gameObject.TryGetComponent<Rifle>(out Rifle rifle))
		{
			KeyBoardManager.SwitchActiveBools(KeyBoardManager.RifleActive);
			Debug.Log("Rifle");
		}
		else if (InventoryController.WeaponsInInventory[selectedWeapon].gameObject.TryGetComponent<Pistol>(out Pistol pistol))
		{
			KeyBoardManager.SwitchActiveBools(KeyBoardManager.PistolActive);
			Debug.Log("Pistol");
		}
		else if (InventoryController.WeaponsInInventory[selectedWeapon].gameObject.TryGetComponent<Sniper>(out Sniper sniper))
		{
			KeyBoardManager.SwitchActiveBools(KeyBoardManager.SniperActive);
			Debug.Log("Sniper");
		}
		else if (InventoryController.WeaponsInInventory[selectedWeapon].gameObject.TryGetComponent<ShotGun>(out ShotGun shotGun))
		{
			KeyBoardManager.SwitchActiveBools(KeyBoardManager.HeavyActive);
			Debug.Log("ShotGun");
		}
	}
}
