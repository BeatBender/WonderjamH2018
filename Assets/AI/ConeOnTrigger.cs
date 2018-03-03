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
            teacherAi.inViewCone1 = true;
        }

        if (o.gameObject.tag == "Player2")
        {
            teacherAi.inViewCone2 = true;
        }
    }

    void OnTriggerExit2D(Collider2D o)
    {


        if (o.gameObject.tag == "Player")
        {
            teacherAi.inViewCone1 = false;
        }

        if (o.gameObject.tag == "Player2")
        {
            teacherAi.inViewCone2 = false;
        }
    }
}
