using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer2StateBehaviour : StateMachineBehaviour {

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        TeacherAi teacherAi = animator.gameObject.GetComponent<TeacherAi>();
        teacherAi.StartWatchingPlayer2();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        TeacherAi teacherAi = animator.gameObject.GetComponent<TeacherAi>();
        teacherAi.StopWatchingPlayer2();
    }
}
