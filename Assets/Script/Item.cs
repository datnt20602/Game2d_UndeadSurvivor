using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
	public ItemData data;

	public int level;
	public PickUpExp pickUpExp; // Tham chiếu đến script PickUpExp để gọi phương thức ẩn giao diện


	Image icon;
	Text textLevel;
	Text textName;
	Text textDesc;

	void Awake()
	{
		icon = GetComponentsInChildren<Image>()[1];
		icon.sprite = data.itemIcon;
		Text[] texts = GetComponentsInChildren<Text>();
		textLevel = texts[0];
		textName = texts[1];
		textDesc = texts[2];
		textName.text = data.itemName;
	}

	void OnEnable()
	{
		switch (data.itemType)
		{
			case ItemData.ItemType.Melee:
                textDesc.text = string.Format(data.itemDesc, data.damages[level]*100);
				break;
            case ItemData.ItemType.Range:
				textDesc.text = string.Format(data.itemDesc, data.damages[level] * 100, data.counts[level]);
				break;

			case ItemData.ItemType.Shoe:
				textDesc.text = string.Format(data.itemDesc, data.damages[level] * 100);
				break;
			default:
				textDesc.text = string.Format(data.itemDesc, data.damages[level]);
				break;

		}

	}

	void LateUpdate()
	{
		textLevel.text = "Lv." + (level + 1);

	}



	public void OnClick()
	{
		switch (data.itemType)
		{
			case ItemData.ItemType.Melee:
				FindObjectOfType<WeaponMelee>().AddElement();
				break;
			case ItemData.ItemType.Range:
				FindObjectOfType<Player>().playerDamage = 1.4f * FindObjectOfType<Player>().playerDamage;
                break;
			case ItemData.ItemType.Shoe:
                FindObjectOfType<Player>().RollDelayTime = FindObjectOfType<Player>().RollDelayTime * (1 - 0.2f);
                break;
			case ItemData.ItemType.Heal:
                FindObjectOfType<Player>().totalHeal = FindObjectOfType<Player>().totalHeal + 100f;
                break;
		}
		level++;

		if (level == data.damages.Length)
		{
			GetComponent<Button>().interactable = false;

		}
		// Sau khi xử lý, gọi phương thức ẩn giao diện từ PickUpExp
		
		
			pickUpExp.HideChooseItemUI();
		
	}
}
