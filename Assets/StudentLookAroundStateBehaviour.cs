using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentLookAroundStateBehaviour : StateMachineBehaviour {

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NerdAi nerdAi = animator.gameObject.GetComponent<NerdAi>();
        nerdAi.LookAround();
    }
}
