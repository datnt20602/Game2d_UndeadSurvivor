using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
	// Update is called once per frame
	
	public float moveSpeed = 5f;
	public Rigidbody2D rb;
	Vector2 movement;
	public Animator animator;

	//Gun and bullet
	public GameObject bullet;
	public Transform firePos;
	public float TimeBtwFire = 0.4f;
	public float bulletForce;

	public float timeBtwFire;

	public SpriteRenderer characterSR;

	private PlayerComponent player;
	private Vector3 playrPos;
	private readonly float DISTANCE_X = 0.24f;
	private readonly float DISTANCE_Y = 0.29f;


	private void Start()
	{
		player = FindObjectOfType<PlayerComponent>();
		playrPos = player.transform.position;
	}

	private void Update()
	{
		if(player != null)
		{
			if (playrPos != player.transform.position)
			{
				playrPos = player.transform.position;
				transform.position = new Vector3(player.transform.position.x - DISTANCE_X,
					player.transform.position.y - DISTANCE_Y, player.transform.position.z);
			}
			RotateGun();

			timeBtwFire -= Time.deltaTime;
			if (Input.GetMouseButton(0) && timeBtwFire < 0)
			{
				FireBullet();
			}
		}

		
	}
	void RotateGun()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Vector2 lookDir = mousePos - transform.position;

		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

		// Rotate the gun only around Z axis
		transform.rotation = Quaternion.Euler(0, 0, angle);

		// Flip the weapon sprite based on the rotation angle
		SpriteRenderer weaponSpriteRenderer = GetComponent<SpriteRenderer>();
		if (lookDir.x < 0)
		{
			// Facing left
			weaponSpriteRenderer.flipY = true;
		}
		else
		{
			// Facing right
			weaponSpriteRenderer.flipY = false;
		}
	}

	void FireBullet()
	{
		timeBtwFire = TimeBtwFire;

		GameObject bulletTmp = Instantiate(bullet, firePos.position, firePos.rotation);

		Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
		
		//rotate the bullet
		bulletTmp.transform.Rotate(Vector3.back, 90);

		// Use the forward direction of the gun for the force direction
		Vector2 bulletForceDirection = transform.right;

		rb.AddForce(bulletForceDirection * bulletForce, ForceMode2D.Impulse);
	}

}
