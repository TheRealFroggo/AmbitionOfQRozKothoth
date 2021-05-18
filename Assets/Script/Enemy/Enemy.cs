using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour , IHealthInterface<int>
{
    public int m_Health;
    public int MaxHealth;
    public float m_Speed;

    public Player TargetPlayer;

    public HealthBarBehaviour HealthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Health = MaxHealth;
        HealthBar.SetMaxHealthValue(MaxHealth);
        HealthBar.SetHealthValue(m_Health);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        ChasePlayer();
    }

    public void TakeDamage(int DamageTaken)
    {
        m_Health -= DamageTaken;
        HealthBar.SetHealthValue(m_Health);

        if (m_Health <= 0)
        {
            Dead();
        }
    }

    public void Heal(int HealAmount)
    {
        m_Health += HealAmount;

        m_Health = Mathf.Clamp(m_Health, 0, m_Health);
    }
    public void Dead()
    {
        Object.Destroy(gameObject);
    }

    void ChasePlayer()
    {
        if(TargetPlayer)
        {
            Vector2 Direction = Vector3.Normalize(TargetPlayer.transform.position - transform.position);

            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.velocity = Direction * m_Speed * Time.fixedDeltaTime;
        }
    }
}
