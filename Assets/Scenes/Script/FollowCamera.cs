using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public GameObject Player;

    public float Speed;
    public float Acceleration;
    public float CameraScaleFactor;
    public float CameraZ;

    void Start()
    {
        m_Camera = Camera.main;
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(2))
        //{
        //    shouldCameraLerp = !shouldCameraLerp;
        //}

        //RotateTowardsCursor();

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Dash();
        //}

    }

    private void FixedUpdate()
    {
        MoveCamera();

    }

    //private void RotateTowardsCursor()
    //{
    //    Vector3 mousePos = Input.mousePosition;
    //    mousePos.z = CameraZ;
    //    Vector3 mousePos3D = this.Camera.ScreenToWorldPoint(mousePos);

    //    this.transform.LookAt(mousePos3D);

    //    Debug.DrawLine(this.transform.position, mousePos3D, Color.white, Time.deltaTime, false);
    //}

    //LOOK AT ME BEN IM SAYING HI
    void MoveCamera()
    {
        if (m_Camera)
        {
            Vector3 playerPos = Player.transform.position;
            Vector3 mousePos = Input.mousePosition;
            Vector3 mousePos3D = m_Camera.ScreenToWorldPoint(mousePos);
            Vector2 direction = (mousePos3D - playerPos) / CameraScaleFactor;

            Vector3 offset = new Vector3(direction.x, direction.y, m_Camera.transform.position.z);

            this.transform.position = playerPos + offset;
        }
    }

    private Camera m_Camera;
}
