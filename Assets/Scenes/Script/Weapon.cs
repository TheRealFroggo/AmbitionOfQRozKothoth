using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float DistanceScale;
    public float MaxDistance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void FixedUpdate()
    {

        GameObject Player = transform.parent.gameObject;
        Camera m_Camera = Camera.main;

        Vector3 playerPos = Player.transform.position;

        Vector3 mousePos = Input.mousePosition;
        Vector3 mousePos3D = m_Camera.ScreenToWorldPoint(mousePos);

        MoveWeapon(mousePos3D, playerPos);

        RotateWeapon(mousePos3D, playerPos);
    }

    private void MoveWeapon(Vector3 MousePos, Vector3 PlayerPos)
    {
        Vector2 direction = (MousePos - PlayerPos) / DistanceScale;

        Vector3 offset = new Vector3(direction.x, direction.y, PlayerPos.z);

        offset.x = Mathf.Clamp(offset.x, -MaxDistance, MaxDistance);
        offset.y = Mathf.Clamp(offset.y, -MaxDistance, MaxDistance);

        transform.position = PlayerPos + offset;
    }

    private void RotateWeapon(Vector3 MousePos, Vector3 PlayerPos)
    {
        Vector3 LookAtDirection = (MousePos - PlayerPos);
        float Angle = Mathf.Atan2(LookAtDirection.x, LookAtDirection.y) * Mathf.Rad2Deg - 90.0f;
        Quaternion rotation = Quaternion.AngleAxis(-Angle, Vector3.forward);

        transform.rotation = rotation;

        if (Mathf.Abs(this.transform.rotation.z * 180) < 90)
        {
            GetComponent<SpriteRenderer>().flipY = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipY = true;
        }
    }
}



