using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 Direction { get; set; }
    public float ProjectileSpeed;

    public float Lifetime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProjectileMovement();

        TickLifetime();
    }

    void ProjectileMovement()
    {
        Vector3 Velocity = Direction * ProjectileSpeed * Time.deltaTime;
        Vector3 GoalPos = this.transform.position + Velocity;

        transform.position = GoalPos;
    }

    private void OnCollisionEnter2D(Collision2D OtherObject)
    {
        IHealthInterface<int> HealthInterface = OtherObject.gameObject.GetComponent<IHealthInterface<int>>();
        if(HealthInterface != null)
        {
            HealthInterface.TakeDamage(5);
        }
        Destroy(gameObject);
    }

    private void TickLifetime()
    {
        Lifetime -= Time.deltaTime;

        if(Lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
