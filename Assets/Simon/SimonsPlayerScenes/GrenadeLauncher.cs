using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
	[SerializeField] GameObject grenadePrefab;
	private Camera playerCam;

	[SerializeField] float throwForce = 5f;


	private bool grenadeReady = false;
	[SerializeField] private float ThrowTimer = 10f;
	private float defaultThrowTimeOffset;

	private KeyBoardManager keyBoardManager;

	private void Start()
	{
		keyBoardManager = FindObjectOfType<KeyBoardManager>();
		playerCam = Camera.main;
	}

	void Update()
	{
		if (keyBoardManager.GrenadePressed() && !grenadeReady)
		{
			grenadeReady = true;
		}
		if (grenadeReady && !keyBoardManager.GrenadePressed())
		{
			ThrowTimer -= Time.deltaTime;
			if (ThrowTimer <= 0.0f)
			{
				ThrowTimer = defaultThrowTimeOffset;
				ThrowGrenade();
				grenadeReady = false;
			}
		}
	}

	void ThrowGrenade()
	{
		GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
		Rigidbody rb = grenade.GetComponent<Rigidbody>();
		rb.AddForce(playerCam.transform.forward * throwForce, ForceMode.VelocityChange);
	}
}
