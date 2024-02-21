using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowDevil : MonoBehaviour
{
    public GameObject bullet;

    private float TimeBetweenFire = 1.5f;
    private float fireCoolDown;
    private float bulletForce = 5f;
    private Vector3 characterPos;
    void Start()
    {
        characterPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < characterPos.x)
        {
            characterPos = transform.position;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x > characterPos.x)
        {
            characterPos = transform.position;
            transform.localScale = new Vector3(1, 1, 1);
        }

        fireCoolDown -= Time.deltaTime;
        if (fireCoolDown < 0)
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        // Add time to delay
        fireCoolDown = TimeBetweenFire;

        // Fire bullet
        GameObject bulletTmp = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D rd = bulletTmp.GetComponent<Rigidbody2D>();
        Vector3 playerPos = FindObjectOfType<Player>().transform.position;
        Vector3 playerPosition = new Vector3(playerPos.x, playerPos.y - 0.5f, playerPos.z);
        Vector3 direction = playerPosition - transform.position;
        rd.AddForce(direction.normalized * bulletForce, ForceMode2D.Impulse);
    }
}
