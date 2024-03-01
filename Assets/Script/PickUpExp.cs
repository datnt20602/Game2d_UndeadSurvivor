using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PickUpExp : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI levelText;
	[SerializeField] private TextMeshProUGUI expText;
	[SerializeField] private int level;
	public float currentExp;
	[SerializeField] private float targetExp;
	[SerializeField] private Image expProgressBar;

	[SerializeField] private GameObject chooseItemUI; // Thêm tham chiếu đến giao diện UI chooseItem
	public Item[] items;



	private void Update()
	{
		//levelText.text = "Level " + level.ToString();
		//expProgressBar.fillAmount = (currentExp / targetExp);
		//expText.text = currentExp + "/" + targetExp;
		expText.text = currentExp + "/" + targetExp;

	}

	public void ExperienceController()
	{

		if (currentExp >= targetExp) //level up
		{

			currentExp = currentExp - targetExp;
			//expProgressBar.fillAmount = (currentExp / targetExp);
			level++;
			targetExp += 50;
			if (chooseItemUI != null)
			{
				Next();
				chooseItemUI.SetActive(true); // Hiển thị giao diện chooseItem khi tăng cấp
			}
		}
		levelText.text = "Level " + level.ToString();
		expProgressBar.fillAmount = (currentExp / targetExp);

	}

	public void HideChooseItemUI()
	{
		if (chooseItemUI != null)
		{
			chooseItemUI.SetActive(false); // Ẩn giao diện chooseItem
		}
	}

	void Next()
	{
		foreach (Item item in items)
		{
			item.gameObject.SetActive(false); //item 	
		}

		int[] ran = new int[3];
		while (true)
		{
			ran[0] = Random.Range(0, items.Length);
			ran[1] = Random.Range(0, items.Length);
			ran[2] = Random.Range(0, items.Length);

			if (ran[0] != ran[1] && ran[1] != ran[2] && ran[2] != ran[0])
				break;
		}

		for (int i = 0; i < ran.Length; i++)
		{
			Item ranItem = items[ran[i]];

			
			if (ranItem.level == ranItem.data.damages.Length)
			{
				items[4].gameObject.SetActive(true);
			}
			else
			{
				ranItem.gameObject.SetActive(true);
			}
		}
	}
}
