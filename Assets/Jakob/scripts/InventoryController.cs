using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
	[SerializeField] GameObject weaponHolder;

	private Camera playerCam;
	private RaycastHit selectedItem;

	[SerializeField] float pickupRange = 2.5f;

	[SerializeField] KeyCode itemPickupKey = KeyCode.B;
	[SerializeField] KeyCode itemDropKey = KeyCode.Q;

	public static List<GameObject> WeaponsInInventory = new List<GameObject>();

	void Start()
    {
		playerCam = Camera.main;

		AddAllWeaponsToInventoryList();
	}

    void Update()
    {
        if(Input.GetKeyDown(itemPickupKey))
		{
			PickupItem();
		}

		if (Input.GetKeyDown(itemDropKey))
		{
			DropItem();
		}
	}

	void AddAllWeaponsToInventoryList()
	{
		for (int i = 0; i < weaponHolder.transform.childCount; i++)
		{
			GameObject weaponHolderChild = weaponHolder.transform.GetChild(i).gameObject;
			if(weaponHolderChild.TryGetComponent(out Weapon weapon))
			{
				WeaponsInInventory.Add(weaponHolderChild);
				Debug.Log($"{weaponHolderChild.transform.name} equipped");
			}
		}
	}

	void PickupItem()
	{
		if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out selectedItem, pickupRange) && selectedItem.transform.TryGetComponent(out Ammunition ammunition))
		{
			Ammunition.pickedUp = true;

			WeaponsInInventory.Add(selectedItem.transform.gameObject);
			Debug.Log($"picked up {selectedItem.transform.name}");
		}
	}

	void DropItem()
	{
		Transform itemToDrop = null;

		for (int i = 0; i < weaponHolder.transform.childCount; i++)
		{
			if (weaponHolder.transform.GetChild(i).tag == "Equipped")
			{
				itemToDrop = weaponHolder.transform.GetChild(i);
			}
		}

		itemToDrop.parent = null;
		itemToDrop.rotation = transform.rotation;
		itemToDrop.transform.position = transform.position;
	}
}
