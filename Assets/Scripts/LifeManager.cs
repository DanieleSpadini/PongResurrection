using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public Timer timer;
    public Rigidbody p;
    public bool isEvent = false;
    public Vector3 playerLife;
    public bool isEventFive = false;

    //When the ball hits the life the paddle gets shorter and faster
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BALL" || other.gameObject.tag == "FAKEBALL" || other.gameObject.tag == "FIREBALL" || other.gameObject.tag == "INVISIBALL")
        {
            p.gameObject.transform.localScale -= new Vector3(0, 2, 0);
            if (isEvent)
            {
                if (isEventFive)
                {
                    isEventFive = false;
                }
                timer.timeLeft = 0;
                isEvent = false;
            }
        }
        if (other.gameObject.tag == "DEATHBALL")
        {
            p.gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    public void LifeHolder()
    {
        playerLife = p.gameObject.transform.localScale;
    }

    public void LifeTaker()
    {
        playerLife -= new Vector3(0, 2, 0);
        p.gameObject.transform.localScale = playerLife;
    }
    public void LifeSet()
    {
        p.gameObject.transform.localScale = playerLife;
    }
}