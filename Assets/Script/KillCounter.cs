using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{

    public Text counterText;
    int kills;
	private void Update()
	{
		showKill();
	}

	public void addKill()
    {
        kills++;
    }

	private void showKill()
	{
		counterText.text = kills.ToString();
	}
}
