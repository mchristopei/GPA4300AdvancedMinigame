using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
	[SerializeField] GameObject explosionEffect;

	[SerializeField] float delay = 3f;
	[SerializeField] float radius = 5f;
	[SerializeField] float force = 700f;

    private bool hasExploded = false;

	private float countdown;

    private bool grenadeReady = false;
    [SerializeField] private float ThrowTimer = 0.5f;
    private float defaultThrowTimeOffset;

    private KeyBoardManager keyBoardManager;
	void Start()
    {
        countdown = delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
		{
            Explode();
            hasExploded = true;
		}        
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObject in colliders)
		{
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
			if (rb != null)
			{
                rb.AddExplosionForce(force, transform.position, radius);
			}


		}

        Destroy(gameObject);
    }
}
