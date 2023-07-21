using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SideWallsMovement : MonoBehaviour
{
	public GameObject go;
	public bool isLeft = false;
	private float speed = 20f;
	public Timer timer;

    //This is for making sure that the moving walls behind the players stay between the upper and lower wall
    private void Update()
    {
        if (timer.timeLeft <= 0)
		{
			speed = 45;
		}
    }

    private void FixedUpdate()
	{
		if (isLeft)
		{
			float y = Mathf.PingPong((Time.time)/45 * speed, 1) * 18 - 9;			
			go.transform.position = new Vector3(-24, y, 0);
		}
		else
		{
			float y = Mathf.PingPong((Time.time)/45 * speed, 1) * 18 - 9;
			y = -y;
			go.transform.position = new Vector3(24, y, 0);
		}
	}
}