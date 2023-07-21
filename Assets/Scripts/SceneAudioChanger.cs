using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneAudioChanger : MonoBehaviour
{
    public AudioClip mainMenuMusic;
    public AudioClip gameLevelMusic;
    public AudioSource gameover;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    void OnSceneChanged(Scene currentScene, Scene nextScene)
    {
        audioSource.Stop();

        if (nextScene.name == "MainMenu")
        {
            audioSource.clip = mainMenuMusic;
        }

        audioSource.Play();
    }
    
}

