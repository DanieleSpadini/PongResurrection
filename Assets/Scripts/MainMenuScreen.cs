using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    //Main menu script for the menu buttons
    public void NewGameButton()
    {
        SceneManager.LoadScene("PongResurrection");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void EventListButton()
    {
        SceneManager.LoadScene("EventListScene");
    }
}