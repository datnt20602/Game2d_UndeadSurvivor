using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	
    public int minDamage;
    public int maxDamage;
    public bool isPlayerBullet;
	public bool isMeleeWeapon;
	int damage;
	public int per;
	Rigidbody2D rigid;
	

	public void Init(int damage, int per, Vector3 dir)
	{
		
		this.damage = damage;   
		this.per = per;         

		if (per >= 0)
		{
			rigid.velocity = dir * 15f; 
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player") && !isPlayerBullet)
		{
			 damage = Random.Range(minDamage, maxDamage);
			collision.GetComponent<PlayerComponent>().TakeDamage(damage);
			Destroy(this.gameObject);
		}
		//if (collision.CompareTag("enemy") && isPlayerBullet && isMeleeWeapon)
		//{
		//	damage = Random.Range(minDamage, maxDamage);
		//	collision.GetComponent<PlayerComponent>().TakeDamage(damage);

		//}
		if (collision.CompareTag("enemy") && isPlayerBullet)
		{
			 damage = Random.Range(minDamage, maxDamage);
			collision.GetComponent<EnemyMovement>().TakeDamage(damage);
			Destroy(this.gameObject);
			
		}
	}
}
