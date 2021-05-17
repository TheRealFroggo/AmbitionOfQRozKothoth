using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour ,IHealthInterface<int>
{
    public float m_Speed;
    public int m_Health;
    public int MaxHealth;
    public float FlickSpeed;

    // Start is called before the first frame update
    void Start()
    {
        m_Health = MaxHealth;
    }

    // Update is called once per frame
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
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(XMovement, YMovement);
    }

    public void TakeDamage(int DamageTaken)
    {
        m_Health -= DamageTaken;

        if(m_Health <= 0)
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

    float m_Time = 0;
}
