using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunStateBehaviour : StateMachineBehaviour {

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NerdAi nerdAi = animator.gameObject.GetComponent<NerdAi>();
        nerdAi.getStun();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NerdAi nerdAi = animator.gameObject.GetComponent<NerdAi>();
        nerdAi.exitStun();
    }
}
