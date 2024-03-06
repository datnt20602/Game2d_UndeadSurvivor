using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;
    public bool isPlayerBullet;
	public bool isWeaponMelee;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player") && !isPlayerBullet)
		{
			int damage = Random.Range(minDamage, maxDamage);
			collision.GetComponent<Player>().TakeDamage(damage);
			Destroy(this.gameObject);
		}
		if (collision.CompareTag("Enermy") && isPlayerBullet)
		{
			int damage = Random.Range(minDamage, maxDamage);
			collision.GetComponent<EnermyController>().TakeDamage(damage);
			if (!isWeaponMelee)
			{
                Destroy(this.gameObject);
            }
		}
	}
}
