using UnityEngine;
using System.Collections;

public class TeacherAi : MonoBehaviour {

    // Where is the player
    private Transform playerTransform1;
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
    private int currentTargeti = 0;
    private int currentTargetj = 1;
    private int waypointsiLength = 3;
    private int waypointsjLength = 3;
    private int pathAxis = 0;
    private Transform[,] waypoints = null;
    private Transform[] coffeeCup = null;

    public float smooth = 1f;
    public bool turnaround = false;
    public bool coffeeBreak = false;
    public int coffeeRandom = 0;
    private int willSeek = 0;
    private int timer = 0;
    private bool stopSeek = false;
    private double seekX = 0;
    private double seekY = 0;

    private bool watchp1 = false;

    // This runs when the teacher is added to the scene
    private void Awake()
    {
        // Get a reference to the player's transform
        playerTransform1 = GameObject.FindGameObjectWithTag("Player1").transform;
        //   playerTransform2 = GameObject.FindGameObjectWithTag("Player2").transform;

        // Get a reference to the FSM (animator)
        animator = gameObject.GetComponent<Animator>();

        // Add all our waypoints into the waypoints array
        Transform point1 = GameObject.Find("Waypoint1").transform;
        Transform point2 = GameObject.Find("Waypoint2").transform;
        Transform point3 = GameObject.Find("Waypoint3").transform;
        Transform point4 = GameObject.Find("Waypoint4").transform;
        Transform point5 = GameObject.Find("Waypoint5").transform;
        Transform point6 = GameObject.Find("Waypoint6").transform;
        Transform point7 = GameObject.Find("Waypoint7").transform;
        Transform point8 = GameObject.Find("Waypoint8").transform;
        Transform point9 = GameObject.Find("Waypoint9").transform;
        Transform coffee = GameObject.Find("Coffee").transform;
        coffeeCup = new Transform[1] { coffee };
        waypoints = new Transform[3, 3] {   { point1, point4, point7 }, 
                                            { point2, point5, point8 }, 
                                            { point3, point6, point9 },
                                        };
        
    }

    private void LateUpdate()
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
        if (!coffeeBreak)
        {
            distanceFromTarget = Vector3.Distance(waypoints[currentTargeti, currentTargetj].position, transform.position);
            animator.SetFloat("distanceFromWaypoint", distanceFromTarget);
        }
        else
        {
            distanceFromTarget = Vector3.Distance(coffeeCup[0].position, transform.position);
            animator.SetFloat("distanceFromWaypoint", distanceFromTarget);
        }
        if (inViewCone1 || inViewCone2)
            inViewCone = true;
        else
            inViewCone = false;
        animator.SetBool("PlayerInSight", inViewCone);

        if (!turnaround && !coffeeBreak && !watchp1)
        {
            willSeek = Random.Range(0, 1200);
            if (willSeek == 1000)
            {
                animator.SetBool("SeekActionEngage", true);
            }
            else if(willSeek==900)
            {
                animator.SetBool("Player1Attention", true);
            }
        }
        else if(turnaround)
        {
            if (seekX < 8 && seekY == 4)
                seekX += 0.1;
            else if (seekX >= 8 && seekY > -4)
                seekY -= 0.1;
            else if (seekX > -8 && seekY <= -4)
                seekX -= 0.1;
            else
            { 
                seekY += 0.1;
                stopSeek = true;
            }

            direction = new Vector3((float)seekX,(float)seekY,0) - transform.position;
            rotateTeacher();
        }

        if(stopSeek)
        {
            stopSeek = false;
            animator.SetBool("SeekActionEngage", false);
        }

        if(watchp1)
        {
            timer++;
            direction = playerTransform1.position - transform.position;
            rotateTeacher();
            if(timer>=250)
            {
                animator.SetBool("Player1Attention", false);
            }
        }

    }

    public void SetNextPoint()
    {
        coffeeRandom = 0;
        if (!coffeeBreak)
        {
            if ((currentTargeti == 0 || currentTargetj == 1) && !(currentTargeti == 0 && currentTargetj == 1))
            {
                coffeeRandom = Random.Range(0, 15);
                if (coffeeRandom == 1)
                {
                    animator.SetBool("CoffeeActionEngage", true);
                    currentTargeti = 0;
                    currentTargetj = 1;
                }
            }
        }

        if (coffeeRandom != 1)
        {
            // Pick a random waypoint 
            // But make sure it is not the same as the last one
            int nextPointi = currentTargeti;
            int nextPointj = currentTargetj;

            do
            {
                pathAxis = Random.Range(0, 2);
                if (pathAxis == 0)
                    nextPointi = Random.Range(0, waypointsiLength);
                else
                    nextPointj = Random.Range(0, waypointsjLength);
            }
            while (nextPointi == currentTargeti && nextPointj == currentTargetj);

            if (nextPointi == 3)
                nextPointi = 0;

            currentTargeti = nextPointi;
            currentTargetj = nextPointj;

            // Load the direction of the next waypoint
            direction = waypoints[currentTargeti, currentTargetj].position - transform.position;
            rotateTeacher();
        }
        else
        {
            direction = new Vector3(coffeeCup[0].position.x, coffeeCup[0].position.y, 0) - transform.position;
            rotateTeacher();
        }
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
        direction = playerTransform1.position - transform.position;
        rotateTeacher();
        watchp1 = true;
        waiting = true;
    }

    public void StopWatchingPlayer1()
    {
        timer = 0;
        direction = oldDirection;
        rotateTeacher();
        watchp1 = false;
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

    public void LookAround()
    {
        seekX = -8;
        seekY = 4;
        oldDirection = direction;
        walkSpeed = 0;
        turnaround = true;
    }

    public void StopLookAround()
    {
        direction = oldDirection;
        rotateTeacher();
        walkSpeed = 2f;
        turnaround = false;
    }

    public void getCoffee()
    {
        coffeeBreak = true;
        // Load the direction of the next waypoint
        direction = new Vector3(coffeeCup[0].position.x, coffeeCup[0].position.y, 0) - transform.position;
        rotateTeacher();
    }

    public void stopDrinkingCoffee()
    {
        animator.SetBool("CoffeeActionEngage", false);
        coffeeBreak = false;
    }

}
