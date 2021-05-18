using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaymoreExplosion : MonoBehaviour
{
    public int m_Damage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsExploding)
        {
            if (ExplosionTimer >= EXPLOSIONTIME)
            {
                Destroy(transform.parent.gameObject);
            }


            ExplosionTimer += Time.deltaTime;
            Debug.Log(ExplosionTimer);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsExploding)
        {
            Enemy CollidingEnemy = collision.gameObject.GetComponent<Enemy>();
            if (CollidingEnemy)
            {
                CollidingEnemy.TakeDamage(m_Damage);
            }
        }
    }

    public void Explode()
    {
        IsExploding = true;
        ExplosionTimer = 0;
    }

    private bool IsExploding = false;
    private const float EXPLOSIONTIME = 0.005f;
    private float ExplosionTimer = 0;
}
