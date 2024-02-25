using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickUpExp : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI levelText;
	[SerializeField] private TextMeshProUGUI expText;
	[SerializeField] private int level;
	public float currentExp;
	[SerializeField] private float targetExp;
	[SerializeField] private Image expProgressBar;

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
		}
		levelText.text = "Level " + level.ToString();
		expProgressBar.fillAmount = (currentExp / targetExp);
	}
}
