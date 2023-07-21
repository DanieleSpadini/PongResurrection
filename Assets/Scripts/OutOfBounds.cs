using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public BallMover rb;
    public bool isUpper = true;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BALL" || other.tag == "FAKEBALL" || other.tag == "DEATHBALL" || other.tag == "FIREBALL")
        {
            if (isUpper)
            {
                rb.transform.position = new Vector3(rb.transform.position.x, 11f, 0);
            }
            else
            {
                rb.transform.position = new Vector3(rb.transform.position.x, -11f, 0);
            }

        }
    }
}
