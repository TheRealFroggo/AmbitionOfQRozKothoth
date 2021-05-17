using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class ProximityMine : Ability
{
    public GameObject MinePrefab;
    public float ThrowPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ActiveAbility(GameObject Parent)
    {
        GameObject Bullet = Instantiate<GameObject>(MinePrefab);

        Bullet.transform.position = Parent.transform.position;
        Bullet.transform.rotation = Parent.transform.rotation;

        Camera m_Camera = Camera.main;

        Vector3 playerPos = Parent.transform.position;

        Vector3 mousePos = Input.mousePosition;
        Vector3 mousePos3D = m_Camera.ScreenToWorldPoint(mousePos);

        mousePos3D.z = 0;

        Vector2 direction = Vector3.Normalize(mousePos3D - playerPos);


        Bullet.GetComponent<Rigidbody2D>().velocity = direction * ThrowPower;

    }
}
