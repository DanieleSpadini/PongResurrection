using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
	private bool pause = false;
	public GameObject gameOverScreen;

	public void Setup()
	{
		if (!gameOverScreen.activeSelf)
		{
			if (pause)
			{
				pause = false;
				gameObject.SetActive(false);
				Time.timeScale = 1;
			}
			else
			{
				pause = true;
				gameObject.SetActive(true);
				Time.timeScale = 0;
			}
		}	
	}

	// Pause screen buttons
	public void RestartButton()
	{
		SceneManager.LoadScene("PongResurrection");
	}

	public void Resume()
	{
		pause = false;
		gameObject.SetActive(false);
		Time.timeScale = 1;
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}