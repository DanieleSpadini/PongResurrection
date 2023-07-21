using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private float rotationSpeed = 250f;
    private float movementSpeed = 40.0f;
    public bool isLeft;
    public float speed = 10f; // speed of circular movement
    public float radius = 10f; // radius of circular movement


    public void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);

        if (isLeft)
        {
            float y = Mathf.PingPong((Time.time) / 45 * movementSpeed, 1) * 18 - 9;
            transform.position = new Vector3(-6, y, 0);
        }
        else
        {
            float y = Mathf.PingPong((Time.time) / 45 * movementSpeed, 1) * 18 - 9;
            y = -y;
            transform.position = new Vector3(6, y, 0);


            //per far fare all'ostacolo un percorso circolare
            ////float x = radius * Mathf.Cos(Time.time * speed);
            ////float yz = radius * Mathf.Sin(Time.time * speed);
            ////Vector2 position = new Vector2(x, yz);


            ////transform.position = position;
        }
    }
}
