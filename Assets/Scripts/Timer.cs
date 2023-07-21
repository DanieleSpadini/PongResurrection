using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float timeLeft;
    public bool timerOn = false;
    public Text timerTxt;
    public GameObject go;
    public bool isMainTimer;

    void Start()
    {
        timerOn = true;
        gameObject.SetActive(true);
    }

    void Update()
    {

        if (timerOn)
        {
            //Color of the timer
            if (timeLeft > 10)
            {
                timerTxt.color = new Color(0.72f, 0.73f, 0.42f);
            }
            else
            {
                timerTxt.color = new Color(0.73f, 0.17f, 0.18f);
            }
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                timerOn = false;
            }
        }
        if (isMainTimer && !timerOn)
        {
            timerTxt.text = "DEATH BALL";
            timeLeft = 1;
        }
    }

    //Timer text updater
    private void UpdateTimer(float currentTime)
    {
        currentTime++;
        timerTxt.text = string.Format("{00}", Mathf.FloorToInt(currentTime));
    }
}