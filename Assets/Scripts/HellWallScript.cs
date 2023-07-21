using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellWallScript : MonoBehaviour
{
	public GameObject hellWall;
	public bool isUp = false;
	public float speed = 30f;
	public BallMover ball;
	public LifeManager isEvent;
	// Start is called before the first frame update
	void Start()
	{

	}

	void FixedUpdate()
	{
		if (isUp)
		{
			float x = Mathf.PingPong((Time.time) / 45 * speed, 1) * 41 - 20.5f;
			hellWall.transform.position = new Vector3(x, 12, -0.001f);
		}
		else
		{
			float x = Mathf.PingPong((Time.time) / 45 * speed, 1) * 41 - 20.5f;
			x = -x;
			hellWall.transform.position = new Vector3(x, -12, -0.001f);
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "BALL")
		{
			ball.FireBall();
		}

	}
}
