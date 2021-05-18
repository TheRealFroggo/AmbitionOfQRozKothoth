using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour ,IHealthInterface<int>
{
    public float m_Speed;
    public int m_Health;
    public int MaxHealth;
    public float FlickSpeed;

    float m_Time = 0;
    public PlayerHealthBehaviour HealthBar;

    void Start()
    {
        m_Health = MaxHealth;
        HealthBar.SetMaxHealthValue(MaxHealth);
        HealthBar.SetHealthValue(m_Health);
    }
    void Update()
    {
        m_Time += Time.deltaTime * FlickSpeed;

        Material SpriteMaterial = GetComponent<Renderer>().material;

        SpriteMaterial.SetFloat("Vector1_43bcc52744ed407a817479d682955a35", m_Time);

    }

    void FixedUpdate()
    {
        float XMovement = Input.GetAxis("Horizontal") * m_Speed;
        float YMovement = Input.GetAxis("Vertical") * m_Speed;


        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(XMovement, YMovement);
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

        m_Health = Mathf.Clamp(m_Health, 0, MaxHealth);
    }

    public void Dead()
    {
        gameObject.SetActive(false);
    }
}
