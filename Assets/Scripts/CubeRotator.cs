using UnityEngine;

public class CubeRotator : MonoBehaviour
{

    private float moveSpeed = 200f;
    public float radius = 5f;
    public float startingAngle = 45f;
    public float rotateSpeed = 400f;

    void Start()
    {
        Vector3 initialPosition = new Vector3(Mathf.Cos(startingAngle), Mathf.Sin(startingAngle), 0) * radius;
        transform.position = initialPosition;
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(Mathf.Cos(Time.time * 5), Mathf.Sin(Time.time * 5), 0) * radius;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}


