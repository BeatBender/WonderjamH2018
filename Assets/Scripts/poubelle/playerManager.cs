using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{


    public static playerManager instance;

    public GameObject sarbacaneShot;
    public GameObject gommeShot;
    public Transform throwPoint;

    //float t;
    public float moveSpeed = 3f;
    private Rigidbody2D theRB;

    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;

    public string lastFacing;

    public bool isMoving;
    public bool faceLeft;
    public bool faceRight;
    public bool faceUp;
    public bool faceDown;

    // Use this for initialization
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == false)
            theRB.velocity = new Vector2(0, 0);

        if (Input.GetKey(left))

            // variables faceLeft, faceRight,... laissées au cas où mais inutiles. A supprimer si nécessaire.

        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
            lastFacing = "left";
            faceLeft = true;
            isMoving = true;
        }
        else
        {
            faceLeft = false;
            isMoving = false;
        }

        if (Input.GetKey(right))
        {
            lastFacing = "right";
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
            faceRight = true;
            isMoving = true;
        }
        else
        {
            faceRight = false;
            isMoving = false;
        }

        if (Input.GetKey(up))
        {
            lastFacing = "up";
            theRB.velocity = new Vector2(theRB.velocity.x, moveSpeed);
            faceUp = true;
            isMoving = true;
        }
        else
        {
            faceUp = false;
            isMoving = false;
        }

        if (Input.GetKey(down))
        {
            lastFacing = "down";
            theRB.velocity = new Vector2(theRB.velocity.x, -moveSpeed);
            faceDown = true;
            isMoving = true;
        }
        else
        {
            faceDown = false;
            isMoving = false;
        }

    }


}
