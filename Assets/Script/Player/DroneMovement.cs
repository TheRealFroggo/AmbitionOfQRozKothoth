using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    [Header("Movement")]
    public float MaxTravelDist;
    public float TopSpeed;
    public float MaxStrafeDist;
    public float PositionSwapTime;
    private float PositionSwapTimer = 0.0f;
    private Vector2 CircleStrafePoint;

    private void Start()
    {
        GenerateCircleStrafe();
    }

    private void Update()
    {
        PositionSwapTimer += Time.deltaTime;
        if (PositionSwapTimer > PositionSwapTime)
        {
            GenerateCircleStrafe();
            PositionSwapTimer = 0.0f;
        }
    }

    void FixedUpdate()
    {
        MoveDrone();
        RotateDrone();
    }

    void MoveDrone()
    {
        Vector2 pos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseStrafePos = mousePos + CircleStrafePoint * MaxStrafeDist;

        float distToStrafePos = Vector2.Distance(mouseStrafePos, pos);

        //Dont move Drone if it gets closer than a certain distance to desired position to avoid jittering
        if (distToStrafePos < 0.1)
            return;

        Vector2 directionToStrafePos = mouseStrafePos - pos;
        directionToStrafePos.Normalize();

        transform.position += new Vector3(directionToStrafePos.x * TopSpeed,
            directionToStrafePos.y * TopSpeed, 0) * Time.fixedDeltaTime;
    }

    void RotateDrone()
    {
        Vector2 pos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 LookAtDirection = mousePos - pos;
        float Angle = Mathf.Atan2(LookAtDirection.x, LookAtDirection.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(-Angle, Vector3.forward);

        transform.rotation = rotation;
    }

    void GenerateCircleStrafe()
    {
        float randRadians = Random.Range(0, 2 * Mathf.PI);
        CircleStrafePoint = new Vector2(Mathf.Cos(randRadians), Mathf.Sin(randRadians));
    }
}
