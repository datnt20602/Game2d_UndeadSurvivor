using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Item",menuName ="Scriptable Object")]
public class ItemData : ScriptableObject
{	public enum ItemType {Range,Shoe,Heal,Melee }
	[Header("# Main infor")]
	public ItemType itemType;
	public int itemId;
	public string itemName;
	[TextArea]
	public string itemDesc;
	public Sprite itemIcon;  

	[Header("# Level data")]
	public float baseDamage;
	public int baseCount;
	public float[] damages;
	public int[] counts;

	[Header("# Weapon")]
	public GameObject projectTile;

}
