using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerdAi : MonoBehaviour {


    // Where is the player
    // private Transform playerTransform1;
    // private Transform playerTransform2;

    // FSM related variables
    private Animator animator;
    bool waiting = false;
    public bool inViewCone;
    public bool inViewCone1;
    public bool inViewCone2;

    // Where is it going and how fast?
    Vector3 direction;
    Vector3 oldDirection;
    private float walkSpeed = 0;
    public float smooth = 1f;
    public bool lookAroundClass = false;
    public bool watchingTeacher=false;
    public bool lookLeft = false;
    public bool stuned = false;
    private double seekX = 0;
    private double updateValue = 0.01;
    private int directionLook = 1;
    private int timer = 0;
    private bool firstcall = true;


    private Transform[] teacherPosition = null;

    // This runs when the teacher is added to the scene
    private void Awake()
    {
        // Get a reference to the player's transform
        //   playerTransform1 = GameObject.FindGameObjectWithTag("Player1").transform;
        //   playerTransform2 = GameObject.FindGameObjectWithTag("Player2").transform;

        // Get a reference to the FSM (animator)
        animator = gameObject.GetComponent<Animator>();

        Transform teacher = GameObject.Find("teacherPrefab").transform;
        teacherPosition = new Transform[1] { teacher };
        seekX = Random.Range(-6, 6);
    }

    private void Update()
    {
        animator.SetBool("Disturbed", stuned);
        // Unless the teacher is waiting then move
        if (!waiting)
        {
            transform.Translate(walkSpeed * direction * Time.deltaTime, Space.World);
        }

    }

    private void FixedUpdate()
    {

        if(stuned)
        {
            if(firstcall)
            {
                if (transform.childCount > 0)
                    transform.GetChild(0).gameObject.SetActive(false);
                firstcall = false;
            }
                
            timer++;
            if (timer >= 150)
            {
                stuned = false;
            }
        }
        else if(timer>=150)
            if (transform.childCount > 0)
                transform.GetChild(0).gameObject.SetActive(true);

        updateValue = Random.Range(1, 600);
        if (updateValue == 3)
            stuned = true;

        if (watchingTeacher && !stuned)
        {
            if (inViewCone1 || inViewCone2)
                inViewCone = true;
            else
                inViewCone = false;
            animator.SetBool("PlayerInSight", inViewCone);

            direction = teacherPosition[0].position - transform.position;

        }
        else if(lookAroundClass || stuned)
        {
            updateValue = Random.Range(1, 15);
            updateValue = updateValue / 60;
            if (seekX <= -6 && lookLeft == true)
                lookLeft = false;
            else if (seekX >= 6 && lookLeft == false)
                lookLeft = true;

            if (lookLeft)
                seekX -= updateValue;
            else
                seekX += updateValue;

            direction = new Vector3((float)seekX, 4, 0) - transform.position;
        }

        rotateNerd();

    }

    public void watchTeacher()
    {
        watchingTeacher = true;
        direction = teacherPosition[0].position - transform.position;
        rotateNerd();
    }

    private void rotateNerd()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        direction = direction.normalized;
    }

    public void ToggleWaiting()
    {
        waiting = !waiting;
    }

    public void StartWatchingPlayer1()
    {
        oldDirection = direction;
        // Load the direction of the player
        //  direction = playerTransform1.position - transform.position;
        rotateNerd();
        waiting = true;
    }

    public void StopWatchingPlayer1()
    {
        direction = oldDirection;
        waiting = false;
    }

    public void StartWatchingPlayer2()
    {
        oldDirection = direction;
        // Load the direction of the player
        //  direction = playerTransform2.position - transform.position;
        rotateNerd();
        waiting = true;
    }

    public void StopWatchingPlayer2()
    {
        direction = oldDirection;
        waiting = false;
    }

    public void LookAround()
    {
        oldDirection = direction;
        walkSpeed = 0;
        lookAroundClass = true;
    }

    public void getStun()
    {
        lookAroundClass = true;
        watchingTeacher = false;
    }

    public void exitStun()
    {
        firstcall = true;
        timer = 0;
        lookAroundClass = false;
        watchingTeacher = true;
    }

}
