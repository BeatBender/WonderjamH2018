using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeOnTrigger : MonoBehaviour
{

    public TeacherAi teacherAi;


    void OnTriggerEnter2D(Collider2D o)
    {

        if (o.gameObject.tag == "Player")
        {
            teacherAi.inViewCone = true;
        }
    }

    void OnTriggerExit2D(Collider2D o)
    {


        if (o.gameObject.tag == "Player")
        {
            teacherAi.inViewCone = false;
        }
    }
}
