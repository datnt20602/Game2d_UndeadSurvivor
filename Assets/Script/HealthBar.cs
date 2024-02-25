using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image fillBar;
	public TextMeshProUGUI healthText;

	public void UpdateHealth(float health, float maxHealth)
	{
		
		fillBar.fillAmount = (float)health / (float)maxHealth;
	}
	public void UpdateBar(int value, int maxValue, string text)
	{
		healthText.text = text;
		fillBar.fillAmount = (float)value / (float)maxValue;
	}
}
