using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public int maxHealth;
	[HideInInspector] public float currentHealth;

	public HealthBar healthBar;

	private float safeTime;
	public float safeTimeDuration = 0f;
	public bool isDead = false;

	public bool camShake = false;

	private void Start()
	{
		currentHealth = maxHealth;

		if (healthBar != null)
			healthBar.UpdateHealth(currentHealth, maxHealth);
	}

	public void TakeDam(float damage)
	{
		if (safeTime <= 0)
		{
			currentHealth -= damage;

			if (currentHealth <= 0)
			{
				currentHealth = 0;
				if (this.gameObject.tag == "Enermy")
				{
					//FindObjectOfType<WeaponManager>().RemoveEnemyToFireRange(this.transform);
					//FindObjectOfType<Killed>().UpdateKilled();
					//FindObjectOfType<PlayerExp>().UpdateExperience(UnityEngine.Random.Range(1, 4));
					Destroy(this.gameObject, 0.125f);
					GetComponent<LootBag>().InstantiateLoot(transform.position);
				}
				isDead = true;
			}

			// If player then update health bar
			if (healthBar != null)
				healthBar.UpdateHealth(currentHealth, maxHealth);

			safeTime = safeTimeDuration;
		}
	}

	private void Update()
	{
		if (safeTime > 0)
		{
			safeTime -= Time.deltaTime;
		}
	}
}
