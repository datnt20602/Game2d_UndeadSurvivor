using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
	public float moveSpeed = 5f;
	public Rigidbody2D rb;
	Vector2 movement;
	public Animator animator;

	public SpriteRenderer characterSR;
	public Rigidbody2D WeaponRB;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Exp"))
		{
			PickUpExp ex = FindObjectOfType<PickUpExp>();
			LootBag loot = collision.GetComponent<LootBag>();
			float expValue = loot.currentLoot.exp;
			ex.currentExp += expValue;
			ex.ExperienceController();
			Destroy(collision.gameObject);
		}
	}


	// Update is called once per frame
	void Update()
	{
		// Input
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		// Update Animator parameters
		UpdateAnimatorParameters();
	}

	void FixedUpdate()
	{
		// Movement
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
		//WeaponRB.MovePosition(WeaponRB.position + movement * moveSpeed * Time.fixedDeltaTime);

		// Flip character sprite based on movement direction
		FlipCharacterSprite();
	}

	void UpdateAnimatorParameters()
	{
		// Update Animator parameters for movement
		animator.SetFloat("Horizontal", movement.x);
		animator.SetFloat("Vertical", movement.y);
		animator.SetFloat("Speed", movement.sqrMagnitude);
	}

	public Transform playerAnimationTransform;
	void FlipCharacterSprite()
	{
		GameObject playerGameObject = GameObject.FindWithTag("Player");
		if (playerGameObject != null)
		{
			playerAnimationTransform = playerGameObject.transform;
			if (movement.x > 0)
			{
				// Moving right
				playerAnimationTransform.localScale = new Vector3(1f, 1f, 1f);
			}
			else if (movement.x < 0)
			{
				// Moving left
				playerAnimationTransform.localScale = new Vector3(-1f, 1f, 1f);

			}
		}


	}


	public Health playerHealth;
	public void TakeDamage(int damage)
	{
		playerHealth.TakeDam(damage);
	}
}

