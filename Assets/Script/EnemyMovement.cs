using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField]
	private float _speed;

	[SerializeField]
	private float _rotationSpeed;

	private Rigidbody2D _rigidbody;
	private PlayerAwarenessController _playerAwarenessController;
	private Vector2 _targetDirection;

	PlayerComponent playerScript;
	public int minDamage;
	public int maxDamage;

	Health enemyHealth;

	private void Start()
	{
		enemyHealth = GetComponent<Health>();
	}
	public void TakeDamage(int damage)
	{
		enemyHealth.TakeDam(damage);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			playerScript = collision.GetComponent<PlayerComponent>();
			InvokeRepeating("DamagePlayer", 0,0.5f);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			playerScript = null;
			CancelInvoke("DamagePlayer");

		}
	}
	void DamagePlayer()
	{
		int damage = UnityEngine.Random.Range(minDamage, maxDamage);
		playerScript.TakeDamage(damage);
	}

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_playerAwarenessController = GetComponent<PlayerAwarenessController>();
	}

	private void FixedUpdate()
	{
		UpdateTargetDirection();
		RotateTowardsTarget();
		SetVelocity();
	}

	private void UpdateTargetDirection()
	{
		if (_playerAwarenessController.AwareOfPlayer)
		{
			_targetDirection = _playerAwarenessController.DirectionToPlayer;
		}
		else
		{
			_targetDirection = Vector2.zero;
		}
	}

	private void RotateTowardsTarget()
	{
		if (_targetDirection == Vector2.zero)
		{
			return;
		}

		Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
		Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

		_rigidbody.SetRotation(rotation);
	}




	private void SetVelocity()
	{
		if (_targetDirection == Vector2.zero)
		{
			_rigidbody.velocity = Vector2.zero;
		}
		else
		{
			_rigidbody.velocity = _targetDirection.normalized * _speed;

			//make enemy not roll 360
			_rigidbody.SetRotation(0f);

			// Flip the enemy based on the horizontal direction
			FlipSprite(_targetDirection.x);
		}
	}

	private void FlipSprite(float horizontalDirection)
	{
		// Flip the sprite if moving left
		if (horizontalDirection < 0)
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}
		// Unflip the sprite if moving right
		else if (horizontalDirection > 0)
		{
			transform.localScale = new Vector3(1, 1, 1);
		}
		// No flip if not moving horizontally
		// You may want to add an else case based on your specific requirements
	}

	// Define event for destruction
	public event Action<GameObject> OnDestroyed;

	// Method to call when enemy is destroyed
	private void OnDestroy()
	{
		OnDestroyed?.Invoke(gameObject);
	}


}
