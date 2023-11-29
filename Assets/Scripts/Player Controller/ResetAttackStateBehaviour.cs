using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAttackStateBehaviour : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //disparity between not moving & the animations..

        animator.SetBool("LightAttack", false);
        animator.SetBool("HeavyAttack", false);

        //if (stateInfo.IsName("LightAttack"))
        //{
        //    animator.SetBool("LightAttack", false);
        //}
        //else if (stateInfo.IsName("HeavyAttack"))
        //{
        //    animator.SetBool("HeavyAttack", false);
        //}

        var controller = animator.GetComponentInParent<StarterAssets.ThirdPersonController>();
        if (controller != null)
        {
            controller.isAttacking = false;
        }
    }
}
