using UnityEngine;

public class Target : MonoBehaviour, IDamagable
{
    public float health{ get; set; }
    [SerializeField] private float Health;

    private void Start()
    {
        health = 50f;
        Health = health;
    }
    private void Update()
    {
        Health = health;
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
