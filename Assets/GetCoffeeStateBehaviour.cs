using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoffeeStateBehaviour : StateMachineBehaviour {

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        TeacherAi teacherAi = animator.gameObject.GetComponent<TeacherAi>();
        teacherAi.getCoffee();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        TeacherAi teacherAi = animator.gameObject.GetComponent<TeacherAi>();
        teacherAi.stopDrinkingCoffee();
    }
    
}
