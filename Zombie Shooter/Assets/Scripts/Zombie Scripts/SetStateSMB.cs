using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStateSMB : StateMachineBehaviour
{
    public int numAnimationRandom;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        int randState = Random.Range(1, numAnimationRandom + 1);
        animator.SetInteger(TagManager.RANDOM_PARAM, randState);
    }

}
