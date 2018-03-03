using UnityEngine;
using System.Collections;

public class TeacherAi : MonoBehaviour {

    // Where is the player
    // private Transform playerTransform1;
    // private Transform playerTransform2;

    // FSM related variables
    private Animator animator;
    bool chasing = false;
    bool waiting = false;
    private float distanceFromTarget;
    public bool inViewCone;
    public bool inViewCone1;
    public bool inViewCone2;

    // Where is it going and how fast?
    Vector3 direction;
    Vector3 oldDirection;
    private float walkSpeed = 2f;
    private int currentTarget;    
    private Transform[] waypoints = null;

    // This runs when the teacher is added to the scene
    private void Awake()
    {
        // Get a reference to the player's transform
        //   playerTransform1 = GameObject.FindGameObjectWithTag("Player1").transform;
        //   playerTransform2 = GameObject.FindGameObjectWithTag("Player2").transform;

        // Get a reference to the FSM (animator)
        animator = gameObject.GetComponent<Animator>();

        // Add all our waypoints into the waypoints array
        Transform point1 = GameObject.Find("Waypoint1").transform;
        Transform point2 = GameObject.Find("Waypoint2").transform;
        Transform point3 = GameObject.Find("Waypoint3").transform;
        Transform point4 = GameObject.Find("Waypoint4").transform;
        Transform point5 = GameObject.Find("Waypoint5").transform;
        waypoints = new Transform[5] {
            point1,
            point2,
            point3,
            point4,
            point5
        };
        
    }

    private void Update()
    {
        // If chasing get the position of the player and point towards it
        if (chasing)
        {
            /*
            if(inViewCone1)
                direction = playerTransform1.position - transform.position;
            else
                direction = playerTransform2.position - transform.position;
                */
            rotateTeacher();
        }

        // Unless the teacher is waiting then move
        if (!waiting)
        {
            transform.Translate(walkSpeed * direction * Time.deltaTime, Space.World);
        }
        
    }

    private void FixedUpdate()
    {
        // Give the values to the FSM (animator)
        distanceFromTarget = Vector3.Distance(waypoints[currentTarget].position, transform.position);
        animator.SetFloat("distanceFromWaypoint", distanceFromTarget);
        if (inViewCone1 || inViewCone2)
            inViewCone = true;
        else
            inViewCone = false;
        animator.SetBool("playerInSight", inViewCone);

    }

    public void SetNextPoint()
    {
        // Pick a random waypoint 
        // But make sure it is not the same as the last one
        int nextPoint = -1;

        do
        {
           nextPoint =  Random.Range(0, waypoints.Length - 1);
        }
        while (nextPoint == currentTarget);

        currentTarget = nextPoint;

        // Load the direction of the next waypoint
        direction = waypoints[currentTarget].position - transform.position;
        rotateTeacher();
    }

    public void Chase()
    {
        /*
        if(inViewCone1)
            direction = playerTransform1.position - transform.position;
        else
            direction = playerTransform2.position - transform.position;
            */
        rotateTeacher();
    }

    public void StopChasing()
    {
        chasing = false;
    }

    private void rotateTeacher()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        direction = direction.normalized;
    }

    public void StartChasing()
    {
        chasing = true;
    }


    public void ToggleWaiting()
    {
        waiting  = !waiting;
    }

    public void StartWatchingPlayer1()
    {
        oldDirection = direction;
        // Load the direction of the player
        //  direction = playerTransform1.position - transform.position;
        rotateTeacher();
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
        rotateTeacher();
        waiting = true;
    }

    public void StopWatchingPlayer2()
    {
        direction = oldDirection;
        waiting = false;
    }

}
