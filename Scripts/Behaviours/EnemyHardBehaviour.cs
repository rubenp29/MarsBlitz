using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHardBehaviour : StateMachineBehaviour
{
    private HardEnemyBehaviour myHardEnemyBehaviour = null;

    private HardEnemyShoot myHardEnemyShoot = null;

    private TripleShoot myTripleShoot = null;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (myHardEnemyBehaviour == null && (myHardEnemyShoot == null || myTripleShoot == null))
        {
            myHardEnemyBehaviour = animator.GetComponent<HardEnemyBehaviour>();

        }

        if (myHardEnemyBehaviour != null && (myHardEnemyShoot != null || myTripleShoot != null))
        {
            myHardEnemyBehaviour.SetAttacking(false);
            myHardEnemyShoot.SetAttacking(false);
            //myTripleShoot.SetAttacking(false);
        }
        else
        {
            myHardEnemyShoot = animator.GetComponent<HardEnemyShoot>();
            myHardEnemyShoot.SetAttacking(false);
            //myTripleShoot = animator.GetComponent<TripleShoot>();
            //myTripleShoot.SetAttacking(false);
        }
    }

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
