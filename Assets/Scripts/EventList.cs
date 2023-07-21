using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class EventList : MonoBehaviour
{
	public Timer timer;
	public Text eventTxt;
	public BallMover ballMover;
	public GameObject go;
	public PlayerMovement playerMovement1;
	public PlayerMovement playerMovement2;
	public GameObject leftObstacle;
	public GameObject rightObstacle;
	public GameObject leftConnector;
	public GameObject rightConnector;
	private bool isEventActive = false;
	private bool textShow = true;
	public GameObject RSideWall;
	public GameObject LSideWall;
	public GameObject p1Life;
	public GameObject p2Life;
	public Passage eventFiveLW;
	public Passage eventFiveRW;
	public GameObject player1;
	public GameObject player2;
	public GameObject hellWallUp;
	public GameObject hellWallDown;
	public Renderer ballRenderer;
	public LifeManager lifeComunicator1;
	public LifeManager lifeComunicator2;
	public Renderer ballcolor;

	//This is the event list 

	public void EventZero()
	{
		ballMover.isMultiball = false;
		GameObject[] killEmAll;
		killEmAll = GameObject.FindGameObjectsWithTag("FAKEBALL");
        for (int i = 0; i < killEmAll.Length; i++)
		{
			Destroy(killEmAll[i].gameObject);
		}
        killEmAll = GameObject.FindGameObjectsWithTag("FAKEFAKEBALL");
        for (int i = 0; i < killEmAll.Length; i++)
        {
            Destroy(killEmAll[i].gameObject);
        }
        isEventActive = false;
		textShow = true;
		playerMovement1.EventOneManager(false);
		playerMovement2.EventOneManager(false);
		ballMover.BallStarter();
		ballMover.StandardBall();
		leftConnector.transform.position = new Vector3(-24.25f, 0, 0);
		rightConnector.transform.position = new Vector3(24.25f, 0, 0);
		leftObstacle.SetActive(false);
		rightObstacle.SetActive(false);
		eventFiveLW.EventFiveManager(false);
		eventFiveRW.EventFiveManager(false);
		playerMovement1.transform.position = new Vector3(-15, 0, 0);
		playerMovement2.transform.position = new Vector3(15, 0, 0);
		p1Life.SetActive(true);
		p2Life.SetActive(true);
		RSideWall.SetActive(true);
		LSideWall.SetActive(true);
		playerMovement1.EventFiveRotationStopper(false);
		playerMovement2.EventFiveRotationStopper(false);
		hellWallDown.SetActive(false);
		hellWallUp.SetActive(false);
		ballRenderer.material.color = new Color(0.72f, 0.73f, 0.42f);
		if (lifeComunicator1.isEventFive)
		{
			eventFiveLW.HpSet();
			lifeComunicator1.isEventFive = false;
		}
		if (lifeComunicator2.isEventFive)
		{
			eventFiveRW.HpSet();
			lifeComunicator2.isEventFive = false;
		}
	}

	public void EventOne()
	{
		if (!isEventActive)
		{
			StartEvent();
			go.SetActive(true);
			eventTxt.text = "Confused controls";
			StartCoroutine(EventTextDismisser());
			playerMovement1.EventOneManager(true);
			playerMovement2.EventOneManager(true);
		}
	}

	public void EventTwo()
	{
		if (!isEventActive)
		{
			ballMover.isMultiball = true;
			ballMover.Spawner();
			StartEvent();
			go.SetActive(true);
			eventTxt.text = "Multiball";
			StartCoroutine(EventTextDismisser());
			ballMover.gameObject.tag = "BALL";	
		}
	}

	public void EventThree()
	{
		if (!isEventActive)
		{
			StartEvent();
			go.SetActive(true);
			eventTxt.text = "Giant ball";
			StartCoroutine(EventTextDismisser());
			ballMover.GiantBall();
			leftConnector.transform.position = new Vector3(-23, 0, 0);
			rightConnector.transform.position = new Vector3(23, 0, 0);
		}
	}

	public void EventFour()
	{
		if (!isEventActive)
		{
			StartEvent();
			go.SetActive(true);
			eventTxt.text = "Obstacle";
			StartCoroutine(EventTextDismisser());
			leftObstacle.SetActive(true);
			rightObstacle.SetActive(true);
		}
	}

	public void EventFive()
	{
		if (!isEventActive)
		{
			StartEvent();
			ballMover.speed = 25;
			eventFiveLW.HpHolder();
			eventFiveRW.HpHolder();
			player1.transform.localScale = new Vector3(1, 6, 1);
			player2.transform.localScale = new Vector3(1, 6, 1);
			go.SetActive(true);
			eventTxt.text = "Classic";
			StartCoroutine(EventTextDismisser());
			playerMovement1.transform.position = new Vector3(-23, 0, 0);
			playerMovement2.transform.position = new Vector3(23, 0, 0);
			p1Life.SetActive(false);
			p2Life.SetActive(false);
			RSideWall.SetActive(false);
			LSideWall.SetActive(false);
			eventFiveLW.EventFiveManager(true);
			eventFiveRW.EventFiveManager(true);
			playerMovement1.EventFiveRotationStopper(true);
			playerMovement2.EventFiveRotationStopper(true);
			playerMovement1.transform.rotation = Quaternion.RotateTowards(transform.rotation, (Quaternion.Euler(0, 0, 180)), 0);
			playerMovement2.transform.rotation = Quaternion.RotateTowards(transform.rotation, (Quaternion.Euler(0, 0, 180)), 0);
			lifeComunicator1.isEventFive = true;
			lifeComunicator2.isEventFive = true;
		}
	}
	public void EventSix()
	{
		if (!isEventActive)
		{
			StartEvent();
			go.SetActive(true);
			eventTxt.text = "Hellfire";
			StartCoroutine(EventTextDismisser());
			hellWallDown.SetActive(true);
			hellWallUp.SetActive(true);
		}
	}

	public void EventSeven()
	{
		if (!isEventActive)
		{
			StartEvent();
			go.SetActive(true);
			eventTxt.text = "Invisiball";
			StartCoroutine(EventTextDismisser());
			ballMover.Invisiball();
		}
	}

	public void EventEight()
	{
        if (!isEventActive)
        {
            ballMover.isMultiball = true;
            ballMover.FakeSpawner();
            StartEvent();
            go.SetActive(true);
            eventTxt.text = "Fake multiball";
            StartCoroutine(EventTextDismisser());
            ballMover.gameObject.tag = "BALL";
        }
    }

	private IEnumerator EventTextDismisser()
	{
		if (textShow)
		{
			yield return new WaitForSeconds(1.5f);
			go.SetActive(false);
			textShow = false;
		}
	}

	private void StartEvent()
	{
		ballMover.go.SetActive(false);
		ballMover.go.SetActive(true);
		ballMover.BallStarter();
		isEventActive = true;
		timer.timeLeft = 15;
		timer.timerOn = true;
		timer.gameObject.SetActive(true);
		GetComponent<AudioSource>().Play();
	}
}