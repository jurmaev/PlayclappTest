using UnityEngine;

public class Cube : MonoBehaviour
{
    private int speed;
    private int distance;
    private float totalDistance;
    private Vector3 previousPosition;
    private Rigidbody rb;

    public int Speed
    {
        set => speed = value;
    }

    public int Distance
    {
        set => distance = value;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        previousPosition = transform.position;
    }

    private void Update()
    {
        if (totalDistance >= distance)
            Destroy(gameObject);
        UpdateTotalDistance();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.forward * speed;
    }

    private void UpdateTotalDistance()
    {
        var distanceVector = transform.position - previousPosition;
        var distanceThisFrame = distanceVector.magnitude;
        totalDistance += distanceThisFrame;
        previousPosition = transform.position;
    }
}