using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float yellowDevilDamage = 18f;
    private float playerDamage;
    public bool isFromPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isFromPlayer)
        {
            collision.GetComponent<Player>().TakeDamage(yellowDevilDamage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Enermy") && isFromPlayer)
        {
            collision.GetComponent<EnermyController>().TakeDamage(playerDamage);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerDamage = FindObjectOfType<Player>().playerDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
