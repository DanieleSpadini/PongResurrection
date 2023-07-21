using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UIElements;


[RequireComponent(typeof(Rigidbody))]

public class BallMover : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 20f;
    private float x;
    private float y;
    public AudioSource[] beep;
    private float maxAxis = 11f;
    public bool isMultiball = false;
    public bool isGiant = false;
    bool isHit = false;
    private float speedMultiplier = 1.02f;
    public GameObject go;
    public Renderer ballColor;
    public Material opaqueMat;
    public Material fadeMat;

    private void Awake()
    {
        ballColor = GetComponent<Renderer>();
    }
    void Start()
    {
        StartCoroutine(Countdown());
    }

    void Update()
    {
        AxisChecker();
        if (isHit)
        {
            isHit = false;
            StartCoroutine(Countdown());
        }
        if (go.tag == "INVISIBALL")
        {
            ballColor.material.color = new Color(0.72f, 0.73f, 0.42f, Mathf.PingPong((Time.time), 0.01f));
        }
    }

    public void BallStarter()
    {
        speed = 20;
        StartCoroutine(Countdown());
    }

    //Resetting the ball position and speed when a player loses a life
    private IEnumerator Countdown()
    {
        rb.velocity = Vector3.zero;
        if (isMultiball)
        {
            rb.transform.position = new Vector3(0, Random.Range(-8f, 8f), 0);
        }
        else
        {
            rb.transform.position = new Vector3(0, 0, 0);
        }
        yield return new WaitForSeconds(1.5f);
        x = Random.value < 0.5f ? -1.0f : 1.0f;
        y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        rb.velocity = new Vector3(speed * x, speed * y, 0);
    }

    //Audio for the ball when hitting a life or a wall/player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            rb.velocity *= speedMultiplier;
        }
        if (collision.gameObject.tag != "LIFE" && rb.tag != "FAKEFAKEBALL")
        {
            beep[Random.Range(0, beep.Length)].Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LIFE" && rb.tag != "FAKEFAKEBALL")
        {
            isHit = true;
        }
    }
    public void Spawner()
    {
        for (int i = 0; i < 2; i++)
        {
            gameObject.tag = "FAKEBALL";
            Instantiate(rb, new Vector3(0, Random.Range(-8f, 8f)), Quaternion.identity);
        }
    }
    public void GiantBall()
    {
        rb.transform.localScale = new Vector3(3, 3, 3);
        maxAxis = 10f;
        isGiant = true;
    }
    public void StandardBall()
    {
        ballColor.material = opaqueMat;
        rb.transform.localScale = new Vector3(1, 1, 1);
        maxAxis = 11f;
        isGiant = false;
        rb.tag = "BALL";
    }

    public void SuddenDeath()
    {
        go.tag = "DEATHBALL";
        BallStarter();
    }
    public void FireBall()
    {
        go.gameObject.tag = "FIREBALL";
        ballColor.material.color = new Color(0.76f, 0.34f, 0.10f);
    }
    public void BallShuffler()
    {
        GameObject[] shuffleEmAll;
        shuffleEmAll = GameObject.FindGameObjectsWithTag("FAKEBALL");
        for (int i = 0; i < shuffleEmAll.Length; i++)
        {
            shuffleEmAll[i].gameObject.transform.position = new Vector3(0, Random.Range(-8f, 8f), 0);
        }
    }

    public void Invisiball()
    {
        ballColor.material = fadeMat;
        go.gameObject.tag = "INVISIBALL";
    }

    public void AxisChecker()
    {
        if (rb.transform.position.y == maxAxis)
        {
            rb.velocity = new Vector3(rb.velocity.x, -10f, 0);
        }
        if (rb.transform.position.y == -maxAxis)
        {
            rb.velocity = new Vector3(rb.velocity.x, 10f, 0);
        }
    }
    public void FakeSpawner()
    {
        for (int i = 0; i < 9; i++)
        {
            gameObject.tag = "FAKEFAKEBALL";
            Instantiate(rb, new Vector3(0, Random.Range(-8f, 8f)), Quaternion.identity);
        }
    }
}
