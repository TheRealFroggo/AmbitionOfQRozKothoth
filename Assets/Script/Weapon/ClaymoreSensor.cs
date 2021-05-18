using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaymoreSensor : MonoBehaviour
{
    public int m_Damage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsExplode)
        {
            ExplodeTimer += Time.deltaTime;
            if (ExplodeTimer >= EXPLODETIME)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsExplode)
        {
            Enemy CollidingEnemy = collision.gameObject.GetComponent<Enemy>();
            if (CollidingEnemy)
            {
                Rigidbody2D rigidBody = transform.parent.GetComponent<Rigidbody2D>();
                List<Collider2D> Contacts = new List<Collider2D>();
                rigidBody.GetContacts(Contacts);

                for (int i = 0; i < Contacts.Count; i++)
                {
                    Enemy EnemyHit = Contacts[i].GetComponent<Enemy>();
                    if (EnemyHit)
                    {
                        EnemyHit.TakeDamage(m_Damage);
                    }
                }
                IsExplode = true;
            }
        }
    }

    bool IsExplode = false;
    const float EXPLODETIME = 0.5f;
    float ExplodeTimer = 0;

}
