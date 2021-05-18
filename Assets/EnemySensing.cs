using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensing : MonoBehaviour
{
    public Enemy SensorOwner;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!SensorOwner.TargetPlayer)
        {
            Player SensedPlayer = collision.GetComponent<Player>();

            if (SensedPlayer != null)
            {
                InRadiusPlayer = SensedPlayer;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (InRadiusPlayer)
        {
            Player SensedPlayer = collision.GetComponent<Player>();

            if (SensedPlayer != null)
            {
                if (SensedPlayer == InRadiusPlayer)
                {
                    InRadiusPlayer = null;
                }
            }
        }
    }

    public void FindPlayer()
    {
        if (InRadiusPlayer)
        {
            Vector2 direction = InRadiusPlayer.transform.position - transform.position;

            int mask = 1 << LayerMask.NameToLayer("Player");
            mask |= 1 << LayerMask.NameToLayer("Default");

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 100, mask);

            if (hit.transform.gameObject == InRadiusPlayer.gameObject)
            {
                SensorOwner.TargetPlayer = InRadiusPlayer;
            }
        }
    }

    private Player InRadiusPlayer;
}
