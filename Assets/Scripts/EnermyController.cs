using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyController : MonoBehaviour
{
    private Player player;

    public bool isCloseCombat;

    public float yellowHeal = 50f;

    public float purpleHeal = 80f;
    public float purpleDamage = 10f;

    Health enemyHealth;

    public event Action<GameObject> OnDestroyed;

    private void Start()
    {
        gameObject.GetComponent<AIDestinationSetter>().target = FindObjectOfType<Player>().transform;
        enemyHealth = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<Player>();
            InvokeRepeating("DamagePlayer", 0.1f, 0.7f);
        }
    }

    public void TakeDamage(float damage)
    {
        enemyHealth.TakeDam(damage);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = null;
            CancelInvoke("DamagePlayer");
        }
    }

    void DamagePlayer()
    {
        if (isCloseCombat)
        {
            player.TakeDamage(purpleDamage);
        }
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(gameObject);
    }
}
