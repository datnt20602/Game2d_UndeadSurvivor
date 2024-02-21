using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Player player;
    private Vector3 playerPos;
    private readonly float DISTANCE_WITH_PLAYER = 0.96f;

    public GameObject bullet;
    public Transform firePos;
    public float TimeBetweenFire = 0.2f;
    public float bulletForce;

    public GameObject muzzle;

    private float timeBtwFire;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        playerPos = player.transform.position;
    }
    void Update()
    {
        if (player.transform.position != playerPos)
        {
            playerPos = player.transform.position;
            transform.position = new Vector3(player.transform.position.x,
            player.transform.position.y - DISTANCE_WITH_PLAYER, player.transform.position.z);
        }
        RotateGun();
        timeBtwFire -= Time.deltaTime;
        if (timeBtwFire < 0)
        {
            FireBullet();
        }
    }
    private void RotateGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookPos = mousePos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void FireBullet()
    {
        // Add time to delay
        timeBtwFire = TimeBetweenFire;

        // Create muzzle
        Instantiate(muzzle, firePos.position, transform.rotation, transform);

        // Fire bullet
        GameObject bulletTmp = Instantiate(bullet, firePos.position, Quaternion.identity);
        Rigidbody2D rd = bulletTmp.GetComponent<Rigidbody2D>();
        rd.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
}
