using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekStateBehaviour : StateMachineBehaviour {

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        TeacherAi teacherAi = animator.gameObject.GetComponent<TeacherAi>();
        teacherAi.LookAround();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        TeacherAi teacherAi = animator.gameObject.GetComponent<TeacherAi>();
        teacherAi.StopLookAround();
    }
}
