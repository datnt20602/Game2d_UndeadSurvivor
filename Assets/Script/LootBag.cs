using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LootBag : MonoBehaviour
{
	public GameObject droppedItemPrefab;
	public List<Loot> lootList = new List<Loot>();
	public Loot currentLoot;

	//private void OnTriggerEnter2D(Collider2D collision)
	//{
	//	PickUpExp ex = FindObjectOfType<PickUpExp>();


	//	if (collision.CompareTag("Player"))
	//	{
	//		// Xử lý logic cho từng loại loot
	//		//float expValue = currentLoot.exp;
	//		//ex.currentExp += expValue;
	//		//ex.ExperienceController();
	//		foreach (Loot loot in lootList)
	//		{
	//			// Xử lý logic cho từng loại loot
	//			float expValue = loot.exp;
	//			ex.currentExp += expValue;
	//			ex.ExperienceController();
	//		}

	//		Destroy(gameObject); // Hủy đối tượng EXP sau khi nhận
	//	}
	//}
	private void Start()
	{
		currentLoot = GetDroppedItems();
	}

	private void Update()
	{
		if (currentLoot != null)
		{	
			currentLoot = lootList.First(item => item.exp == currentLoot.exp);
			this.GetComponent<SpriteRenderer>().sprite = currentLoot.lootSprite;
		}
	}

	Loot GetDroppedItems()
	{
		int randomNumber = Random.Range(1, 101); //1-100
		List<Loot> possibleItem = new List<Loot>();
		foreach (Loot item in lootList)
		{
			if (randomNumber <= item.dropChance)
			{
				possibleItem.Add(item);
			}
		}
		if (possibleItem.Count > 0)
		{
			Loot droppedItem = possibleItem[Random.Range(0, possibleItem.Count)];
			return droppedItem;
		}
		Debug.Log("No loot dropped");
		return null;
	}
	public void InstantiateLoot(Vector3 spawnPosition)
	{
		Loot droppedItem = currentLoot;

		if (droppedItem != null)
		{
			GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
			lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;

			float dropForce = 200f;
			Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

			Rigidbody2D rb = lootGameObject.GetComponent<Rigidbody2D>();
			rb.AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
			rb.drag = 1f; // Giảm dần lực theo thời gian

		}
	}


}






