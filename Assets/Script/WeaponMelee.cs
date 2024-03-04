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

	 void Update()
	{
		if (listBullet == null)
		{

		}
		transform.position = FindObjectOfType<Player>().transform.position;
		transform.Rotate(Vector3.back * speed * Time.deltaTime);
	}

	public void AddElement()
	{
		listBullet.Add(gameObject);
		if (listBullet.Count == 1)
		{
			 
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
