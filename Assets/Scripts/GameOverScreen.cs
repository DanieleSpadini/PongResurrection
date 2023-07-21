using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{
	public Text txt;

	//This is the winner text and the game and the "game over" buttons
	public void Setup(string winner)
	{
		gameObject.SetActive(true);
		Time.timeScale = 0;
		txt.text = $"Looks like you get to live, {winner}...";
	}

	public void RestartButton()
	{
		SceneManager.LoadScene("PongResurrection");	
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}