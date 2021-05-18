using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 Direction { get; set; }
    public float ProjectileSpeed;

    public float Lifetime;
    public int Damage;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IHealthInterface<int> HealthInterface = collision.gameObject.GetComponent<IHealthInterface<int>>();
        if (HealthInterface != null)
        {
            HealthInterface.TakeDamage(Damage);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHealthInterface<int> HealthInterface = collision.gameObject.GetComponent<IHealthInterface<int>>();
        if (HealthInterface != null)
        {
            HealthInterface.TakeDamage(Damage);
        }

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            if (Owner)
            {
                enemy.TargetPlayer = Owner;
            }
        }

        Destroy(gameObject);
    }

    private void TickLifetime()
    {
        Lifetime -= Time.deltaTime;

        if (Lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public Player Owner { get; set; }
}
