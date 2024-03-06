using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed = -150;
    public GameObject element;
    public List<GameObject> listBullet;

    private void Start()
    {
        transform.localScale = new Vector3(1, 1, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        //AddElement();
    }

    void Update()
    {
        if (listBullet == null)
        {

        }
        Vector3 playerPosition = FindObjectOfType<Player>().transform.position;
        transform.position = new Vector3(playerPosition.x, playerPosition.y - 0.5f, playerPosition.z);
        transform.Rotate(Vector3.back * speed * Time.deltaTime);
    }

    public void AddElement()
    {
        GameObject newElement = Instantiate(element);
        newElement.transform.parent = transform;
        listBullet.Add(newElement);
        if (listBullet.Count > 0)
        {
            float weaponRotation = -360f / (float)listBullet.Count;
            for (int i = 0; i < listBullet.Count; i++)
            {
                float currentRotationRadian = (float) (Math.PI * weaponRotation * i) / 180f;
                float currentRotation = (float) weaponRotation * i;
                float additionPositionX = (float) Math.Cos(currentRotationRadian) * 1.5f;
                float additionPositionY = (float) Math.Sin(currentRotationRadian) * 1.5f;
                Vector3 additionPosition = new Vector3(additionPositionX, additionPositionY, 0);
                listBullet[i].transform.position = listBullet[i].transform.parent.position + additionPosition;
                listBullet[i].transform.rotation = Quaternion.Euler(0, 0, currentRotation);
            }
        }
    }
    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = -150;
                Batch();
                break;
            default:
                break;
        }
    }

    void Batch()
    {
        for (int i = 0; i < count; i++)
        {

        }
    }
}
