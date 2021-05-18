using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehaviour : EnemyStateBase
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!GetEnemyController(animator).TargetPlayer)
        {
            animator.SetBool("IsThereTarget", false);
            return;
        }

        Rigidbody2D rigidbody = GetEnemyController(animator).GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector3.zero;

        GetEnemyController(animator).Attack();

        animator.SetTrigger("AlreadyAttack");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Rigidbody2D rigidbody = GetEnemyController(animator).GetComponent<Rigidbody2D>();
        //rigidbody.velocity = Vector3.zero;

        //GetEnemyController(animator).Attack();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
