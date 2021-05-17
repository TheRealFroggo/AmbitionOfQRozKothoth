using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LaserGun : Ability
{
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
        Weapon weapon =  Parent.GetComponentInChildren<Weapon>();
        weapon.PrimaryAttack();
    }
}
