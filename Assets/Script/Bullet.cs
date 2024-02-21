using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;
    public bool isPlayerBullet;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player") && !isPlayerBullet)
		{
			int damage = Random.Range(minDamage, maxDamage);
			collision.GetComponent<PlayerComponent>().TakeDamage(damage);
			Destroy(this.gameObject);
		}
		if (collision.CompareTag("enemy") && isPlayerBullet)
		{
			int damage = Random.Range(minDamage, maxDamage);
			collision.GetComponent<EnemyMovement>().TakeDamage(damage);
			Destroy(this.gameObject);
		}
	}
}
