using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
	[SerializeField] GameObject grenadePrefab;
	private Camera playerCam;

	[SerializeField] float throwForce = 40f;
	[SerializeField] KeyCode throwGrenadeButton = KeyCode.G;

	private void Start()
	{
		playerCam = Camera.main;
	}

	void Update()
    {
		if (Input.GetKeyDown(throwGrenadeButton))
		{
            ThrowGrenade();
		}
    }

    void ThrowGrenade()
	{
		GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
		Rigidbody rb = grenade.GetComponent<Rigidbody>();
		rb.AddForce(playerCam.transform.forward * throwForce, ForceMode.VelocityChange);
	}
}
