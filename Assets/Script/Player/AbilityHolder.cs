using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability PrimaryAbility;
    public Ability SecondaryAbility;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PrimaryAttack();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SecondaryAbility.ActiveAbility(gameObject);
        }
    }

    void PrimaryAttack()
    {
            PrimaryAbility.ActiveAbility(gameObject);
    }

    
}
