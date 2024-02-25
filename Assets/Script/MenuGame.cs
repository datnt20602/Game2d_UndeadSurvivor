using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
   public void NewGame()
	{
		SceneManager.LoadScene(1);
	}

	public void BackToMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void Exit()
	{
		Application.Quit();
	}
}
