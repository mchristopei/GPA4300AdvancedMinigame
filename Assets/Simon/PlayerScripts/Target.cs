using UnityEngine;

public class Target : MonoBehaviour, IDamagable
{
    public float health{ get; set; }

    private void Start()
    {
        health = 50f;
    }
    private void Update()
    {
        Die();
    }
    void Die()
	{
		if(health <= 0)
        {
			Destroy(gameObject);
        }
	}
}
