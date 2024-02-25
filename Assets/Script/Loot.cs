using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
	public Sprite lootSprite;
	public string lootName;
	public int dropChance;
	public float exp;

	public Loot( string lootName, int dropChance, float exp)
	{
		
		this.lootName = lootName;
		this.dropChance = dropChance;
		this.exp = exp;
	}

}
