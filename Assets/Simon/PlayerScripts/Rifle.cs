using UnityEngine;
using System.Collections;

public class Rifle : MonoBehaviour
{
	public float damage = 10f;
	public float bulletForce = 400f;
	public float range = 100f;
	public float fireRate = 15f;
	public int maxAmmo = 25;
	private int currentAmmo;
	public float reloadTime = 1f;
	private bool isReloading = false;

	public Camera fpsCam;
	//public GameObject weaponHolder;
	public ParticleSystem muzzleFlash;
	public GameObject impactEffect;
	public Animator animator;

	private float nextTimeToFire = 0f;

	private void Start()
	{
		currentAmmo = maxAmmo;
	}

	// Update is called once per frame
	void Update()
	{
		//Equipcheck
		if (transform.parent == null)
		{
			return;
		}
		else
		{
			transform.GetComponent<Animator>().enabled = true;
		}

		if (isReloading)
			return;

		if (currentAmmo <= 0)
		{
			StartCoroutine(Reload());
			return;
		}

		if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
		{
			//weaponHolder.GetComponent<WeaponSwitching>().canSwitch = false;

			nextTimeToFire = Time.time + 1f / fireRate;
			Shoot();
			animator.SetBool("Shoot", true);
		}
		else
		{
			animator.SetBool("Shoot", false);
			//weaponHolder.GetComponent<WeaponSwitching>().canSwitch = true;
		}
	}

	IEnumerator Reload()
	{
		isReloading = true;
		Debug.Log("Reloading...");

		//weaponHolder.GetComponent<WeaponSwitching>().canSwitch = false;

		animator.SetBool("Reloading", true);
		yield return new WaitForSeconds(reloadTime - .25f);
		animator.SetBool("Reloading", false);
		yield return new WaitForSeconds(.25f);

		currentAmmo = maxAmmo;
		//weaponHolder.GetComponent<WeaponSwitching>().canSwitch = true;
		isReloading = false;
	}

	void Shoot()
	{
		muzzleFlash.Play();

		currentAmmo--;

		RaycastHit hit;
		if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
		{
			switch (hit.transform.tag)
			{
				case "LootCrate":
					//CrateTarget target = hit.transform.GetComponent<CrateTarget>();
				
					//if (target != null)
					//{
					//	target.TakeDamage(damage);
					//
					//	GameObject ImpactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
					//	Destroy(ImpactGO, 1f);
					//}
					//break;

				default:
					Debug.Log(hit.transform.name);

					Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
					if (rb != null)
					{
						rb.AddExplosionForce(bulletForce, hit.point, 0.5f);
					}

					if (hit.transform.name != "Player")
					{
						GameObject ImpactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
						Destroy(ImpactGO, 1f);
					}
					break;
			}
		}
	}
}
