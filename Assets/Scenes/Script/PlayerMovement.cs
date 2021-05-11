using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float XMovement = Input.GetAxis("Horizontal") * m_Speed * Time.deltaTime;
        float YMovement = Input.GetAxis("Vertical") * m_Speed * Time.deltaTime;
        transform.position += new Vector3(XMovement, YMovement, 0);
    }
}
