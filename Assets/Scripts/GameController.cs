using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public EventList el;
    public GameOverScreen gameOverScreen;
    public Pause pause;
    public GameObject p1;
    public GameObject p2;
    public BallMover ball;
    public Timer timer;
    public Timer eventTimer;
    public Text timerTxt;
    private int eventcounter = 0;
    public LifeManager lm1;
    public LifeManager lm2;
    private bool isEventPlaying = false;
    private bool[] eventList = new bool[8];
    public AudioSource gameover;
    public AudioSource gameMusic;
    public AudioSource suddenDeathSong;
    public Renderer ballcolor;
    public GameObject deathCube;

    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(TimerAppearer());
        for (int i = 0; i < eventList.Length; i++)
        {
            eventList[i] = true;
        }
    }

    private void Update()
    {
        CheckPause();
        if ((timer.timeLeft <= 30 && eventcounter == 0) ||
            (timer.timeLeft <= 20 && eventcounter == 1) ||
            (timer.timeLeft <= 10 && eventcounter == 2))
        {
            lm1.isEvent = true;
            lm2.isEvent = true;
            timer.gameObject.SetActive(false);
            timerTxt.gameObject.SetActive(false);
            eventTimer.gameObject.SetActive(true);
            eventcounter++;
            EventPlayer(EventExtract());
            isEventPlaying = true;
        }
        if (eventTimer.timeLeft <= 0 && isEventPlaying)
        {
            switch (eventcounter)
            {
                case 1:
                    timer.timeLeft = 30;
                    break;
                case 2:
                    timer.timeLeft = 20;
                    break;
                case 3:
                    timer.timeLeft = 10;
                    break;
            }
            isEventPlaying = false;
            el.EventZero();
            StartCoroutine(TimerAppearer());
        }

        if (timer.timeLeft <= 0)
        {
            ball.SuddenDeath();
            ball.speed = 20;
            ballcolor.material.color = new Color(0.73f, 0.17f, 0.18f);
            gameMusic.Stop();
            suddenDeathSong.Play();
            deathCube.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        GameOver();
    }

    public void GameOver()
    {
        if (p1.transform.localScale.y == 0)
        {
            gameOverScreen.Setup("player two");
            gameMusic.Stop();
            suddenDeathSong.Stop();
            gameover.Play();
        }
        else if (p2.transform.localScale.y == 0)
        {
            gameOverScreen.Setup("player one");
            gameMusic.Stop();
            suddenDeathSong.Stop();
            gameover.Play();
        }
    }

    void CheckPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.Setup();
        }
    }

    private int EventExtract()
    {
        int evnt;
        do
        {
            evnt = Random.Range(1, 8);

        } while (eventList[evnt - 1] != true);
        eventList[evnt - 1] = false;
        return evnt;
    }

    //This is the event pool

    void EventPlayer(int evento)
    {
        switch (evento)
        {
            case 1:
                el.EventOne();
                break;
            case 2:
                el.EventTwo();
                break;
            case 3:
                el.EventEight();
                break;
            case 4:
                el.EventFour();
                break;
            case 5:
                el.EventFive();
                break;
            case 6:
                el.EventSix();
                break;
            case 7:
                el.EventSeven();
                break;
            case 8:
                el.EventThree();
                break;
        }
    }
    public IEnumerator TimerAppearer()
    {
        yield return new WaitForSeconds(1.5f);
        eventTimer.gameObject.SetActive(false);
        timer.gameObject.SetActive(true);
        timerTxt.gameObject.SetActive(true);
    }
}