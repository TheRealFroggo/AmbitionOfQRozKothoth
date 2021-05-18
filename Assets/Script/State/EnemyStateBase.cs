using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateBase : StateMachineBehaviour
{
    private Enemy BehaviourOwner;
    private EnemySensing OwnerSensing; 

    public Enemy GetEnemyController(Animator animator)
    {
        if(!BehaviourOwner)
        {
            BehaviourOwner = animator.GetComponent<Enemy>();
        }
        return BehaviourOwner;
    }

    public EnemySensing GetEnemySensingComponent(Animator animator)
    {
        if (!OwnerSensing)
        {
            OwnerSensing = animator.gameObject.GetComponentInChildren<EnemySensing>();
        }
        return OwnerSensing;
    }

}
