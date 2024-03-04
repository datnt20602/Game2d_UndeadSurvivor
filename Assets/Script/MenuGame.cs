using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGame : MonoBehaviour
{
	public Button exitButton;
    private void Start()
    {
        //exitButton.onClick.AddListener(BackToMenu);
    }

    public void NewGame()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(1);
	}

	public void BackToMenu()
	{
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
	}

	public void Exit()
	{
		Application.Quit();
	}
}
