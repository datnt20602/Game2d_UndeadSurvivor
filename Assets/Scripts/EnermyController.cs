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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<Player>();
            InvokeRepeating("DamagePlayer", 0.1f, 0.7f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = null;
            CancelInvoke("DamagePlayer");
        }
    }

    public void TakeDamage(float damage)
    {
        if (isCloseCombat)
        {
            purpleHeal -= damage;
        } else
        {
            yellowHeal -= damage;
        }
    }

    void DamagePlayer()
    {
        if (isCloseCombat)
        {
            player.TakeDamage(purpleDamage);
        }
    }

    private void Update()
    {
        if (isCloseCombat)
        {
            if (purpleHeal <= 0)
            {
                Destroy(gameObject);
            }
        } else
        {
            if (yellowHeal <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
