using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Passage : MonoBehaviour
{
    public Transform connection;
    public Rigidbody ball;
    public bool isEventFive = false;
    public LifeManager lM;
    public Timer eventTimer;
    public AudioSource beep;


    private void OnTriggerEnter(Collider other)
    {
        if (!isEventFive)
        {
            float ballPos = ball.transform.position.y;
            Vector3 position = other.transform.position;
            position.x = this.connection.position.x;
            position.y = -ballPos;
            other.transform.position = position;
        }
        else
        {
            lM.LifeTaker();
            lM.timer.timeLeft = 0;
            lM.isEvent = false;
            beep.Play();
        }

    }

    public void EventFiveManager(bool manager)
    {
        isEventFive = manager;
    }

    public void HpHolder()
    {
        lM.LifeHolder();
    }

    public void HpSet()
    {
        lM.LifeSet();
    }
}
