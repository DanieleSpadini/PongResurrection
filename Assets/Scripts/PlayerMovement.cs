using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    public float paddleSpeed = 10f;
    public Rigidbody rb = null;
    float axisY;
    private bool isLeftCtrlPressed;
    private bool isRightCtrlPressed;
    private float z = 180;
    public Rigidbody uBorder;
    public Rigidbody lBorder;
    private float playerMinY;
    private float playerMaxY;
    public Rigidbody ball;
    public bool isPlayer1;
    public bool isEventOne = false;
    public float speedRotation = 400f;
    public Timer eventTimer;
    public AudioSource losingHealth;
    private bool isEventFive = false;
    public LifeManager collided;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    //This is for making sure that the player stays in the game walls, even when it get shorter

    private void Update()
    {
        playerMinY = lBorder.position.y + lBorder.transform.localScale.y / 2 + transform.localScale.y / 2;
        playerMaxY = uBorder.position.y - uBorder.transform.localScale.y / 2 - transform.localScale.y / 2;
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isLeftCtrlPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            isRightCtrlPressed = true;
        }
    }
    void FixedUpdate()

    {
        if (isPlayer1)
        {
            if (isEventOne)
            {
				if (eventTimer.timeLeft <= 2)
				{
					axisY = -Input.GetAxis("Vertical");
                }
				else if (eventTimer.timeLeft <= 5)
				{
					axisY = Input.GetAxis("Vertical");
				}
				else if (eventTimer.timeLeft <= 8)
				{
					axisY = -Input.GetAxis("Vertical");
				}
				else if (eventTimer.timeLeft <= 11)
                {
                    axisY = Input.GetAxis("Vertical");
                }
                else if (eventTimer.timeLeft <= 14)
                {
                    axisY = -Input.GetAxis("Vertical");
                }
                else if (eventTimer.timeLeft <= 17)
                {
                    axisY = Input.GetAxis("Vertical");
                }
                else if (eventTimer.timeLeft <= 20)
                {
                    axisY = -Input.GetAxis("Vertical");
                }
            }
            else
            {
                axisY = Input.GetAxis("Vertical");
            }

            if (isLeftCtrlPressed && !isEventFive)
            {
                //if (!rotatefwd)
                //{
                transform.rotation = Quaternion.RotateTowards(transform.rotation, (Quaternion.Euler(0, 0, z)), speedRotation * Time.deltaTime);
                //}
                //else
                //{
                //    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Inverse(Quaternion.Euler(0, 0, z)), speedRotation * Time.deltaTime);
                //}
                //rotatefwd = !rotatefwd;
                if (transform.rotation.eulerAngles.z == 180)
                {
                    z = 0;
                    isLeftCtrlPressed = false;
                }
                if (transform.rotation.eulerAngles.z == 0)
                {
                    z = 180;
                    isLeftCtrlPressed = false;
                }
            }
        }

        else
        {
            if (isEventOne)
            {
				if (eventTimer.timeLeft <= 2)
				{
					axisY = -Input.GetAxis("Vertical2");
				}
				else if (eventTimer.timeLeft <= 5)
				{
					axisY = Input.GetAxis("Vertical2");
				}
				else if (eventTimer.timeLeft <= 8)
				{
					axisY = -Input.GetAxis("Vertical2");
				}
				else if (eventTimer.timeLeft <= 11)
				{
					axisY = Input.GetAxis("Vertical2");
				}
				else if (eventTimer.timeLeft <= 14)
				{
					axisY = -Input.GetAxis("Vertical2");
				}
				else if (eventTimer.timeLeft <= 17)
				{
					axisY = Input.GetAxis("Vertical2");
				}
				else if (eventTimer.timeLeft <= 20)
				{
					axisY = -Input.GetAxis("Vertical2");
				}
			}
            else
            {
                axisY = Input.GetAxis("Vertical2");
            }
            if (isRightCtrlPressed && !isEventFive)
            {
                //if (rotatefwd)
                //{
                //    transform.rotation = Quaternion.RotateTowards(transform.rotation, (Quaternion.Euler(0, 0, z)), speedRotation * Time.deltaTime);
                //}
                //else
                //{
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Inverse(Quaternion.Euler(0, 0, z)), speedRotation * Time.deltaTime);
                //}
                //rotatefwd = !rotatefwd;
                if (transform.rotation.eulerAngles.z == 180)
                {
                    z = 0;
                    isRightCtrlPressed = false;
                }
                if (transform.rotation.eulerAngles.z == 0)
                {
                    z = 180;
                    isRightCtrlPressed = false;
                }
            }
        }
        transform.position += new Vector3(0, axisY * paddleSpeed * Time.deltaTime, 0);
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, playerMinY, playerMaxY));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BALL")
        {
            rb.transform.position = new Vector3(rb.transform.position.x, 0, 0);
            losingHealth.Play();
        }
        if (other.tag == "FAKEBALL" || other.tag == "INVISIBALL" || other.tag == "FIREBALL")
        {
            losingHealth.Play();
        }
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "DEATHBALL")
		{
			rb.gameObject.transform.localScale = new Vector3(0, 0, 0);
		}
		if (collision.gameObject.tag == "FIREBALL")
		{
			rb.gameObject.transform.localScale -= new Vector3(0, 2, 0);
			collided.timer.timeLeft = 0;
            losingHealth.Play();
		}
	}
    public void EventOneManager(bool manager)
    {
        isEventOne = manager;
    }
    public void EventFiveRotationStopper(bool manager)
    {
        isEventFive = manager;
    }

    // Those are some tries for the alternator of "Consufed controls" event

    //private IEnumerator AlternatorP1()
    //{
    //    yield return null;
    //    axisY = -Input.GetAxis("Vertical");
    //    yield return new WaitForSeconds(3f);
    //    axisY = Input.GetAxis("Vertical");
    //    yield return new WaitForSeconds(3f);
    //    axisY = -Input.GetAxis("Vertical");
    //    yield return new WaitForSeconds(3f);
    //    axisY = Input.GetAxis("Vertical");
    //    yield return new WaitForSeconds(3f);
    //    axisY = -Input.GetAxis("Vertical");
    //    yield return new WaitForSeconds(3f);
    //    axisY = Input.GetAxis("Vertical");
    //    yield return new WaitForSeconds(3f);
    //    axisY = -Input.GetAxis("Vertical");
    //    yield return new WaitForSeconds(2f);
    //    axisY = Input.GetAxis("Vertical");
    //}

    //private IEnumerator AlternatorP2()
    //{
    //    yield return null;
    //    axisY = -Input.GetAxis("Vertical2");
    //    yield return new WaitForSeconds(3f);
    //    axisY = Input.GetAxis("Vertical2");
    //    yield return new WaitForSeconds(3f);
    //    axisY = -Input.GetAxis("Vertical2");
    //    yield return new WaitForSeconds(3f);
    //    axisY = Input.GetAxis("Vertical2");
    //    yield return new WaitForSeconds(3f);
    //    axisY = -Input.GetAxis("Vertical2");
    //    yield return new WaitForSeconds(3f);
    //    axisY = Input.GetAxis("Vertical2");
    //    yield return new WaitForSeconds(3f);
    //    axisY = -Input.GetAxis("Vertical2");
    //    yield return new WaitForSeconds(2f);
    //    axisY = Input.GetAxis("Vertical2");
    //}

}
