using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class sarbacaneShot : MonoBehaviour
{

    bool isSetted = false;

    public float sarbacaneSpeed = 10f;

    private Rigidbody2D theRB;

    private Vector2 direction;

    private Vector3 orientation;

    private float moveHorizontal1, moveVertical1;

    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), PlayerController1.instance.GetComponent<Collider2D>());
        theRB = GetComponent<Rigidbody2D>();
        direction = Vector2.right;
        orientation = transform.rotation.eulerAngles;
    }

    void FixedUpdate()
    {

        moveHorizontal1 = Input.GetAxis("HorizontalPlayer1");
        moveVertical1 = Input.GetAxis("VerticalPlayer1");

        if (isSetted == false)
        {

            //if (PlayerController1.instance.lastFacing == "right")
            //{
            //    orientation.z = -90;
            //    transform.rotation = Quaternion.Euler(orientation);
            //    direction = new Vector2(1, 0);
            //    isSetted = true;
            //}

            //if (PlayerController1.instance.lastFacing == "left")
            //{
            //    orientation.z = 90;
            //    transform.rotation = Quaternion.Euler(orientation);
            //    direction = new Vector2(-1, 0);
            //    isSetted = true;
            //}

            //if (PlayerController1.instance.lastFacing == "down")
            //{
            //    orientation.z = 180;
            //    transform.rotation = Quaternion.Euler(orientation);
            //    direction = new Vector2(0, -1);
            //    isSetted = true;
            //}

            //if (PlayerController1.instance.lastFacing == "up")
            //{
            //    orientation.z = 0;
            //    transform.rotation = Quaternion.Euler(orientation);
            //    direction = new Vector2(0, 1);
            //    isSetted = true;
            //}

            //orientation.x = PlayerController1.instance.wasFacing.x;
            //orientation.y = PlayerController1.instance.wasFacing.y;
            //transform.rotation = Quaternion.Euler(orientation);
            //if (moveHorizontal1 != 0)
            //    orientation.z = moveHorizontal1;

            //if (moveVertical1 != 0)
            //    orientation.z = moveVertical1;

            direction = PlayerController1.instance.wasFacing;
            theRB.velocity = direction * sarbacaneSpeed;
            isSetted = true;
        }
        
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Player")
            Destroy(gameObject);
    }
}
