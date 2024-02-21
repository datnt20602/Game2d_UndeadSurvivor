using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float yellowDevilDamage = 18f;
    public float playerDamage = 20f;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
