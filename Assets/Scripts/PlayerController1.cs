using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour {

    public float speed = 2f;
    private float moveHorizontal1, moveVertical1;
    public GameObject ecriture;
    public Vector3 offset;
    private bool tableauHit = false;
    private const float maxTimer = 5f;
    private float timer = maxTimer;
<<<<<<< HEAD
    public bool faceRight, faceLeft, faceUp, faceDown, isMoving;

    //Aymeric's variables
    public static PlayerController1 instance;
    private Rigidbody2D theRB;
    public GameObject sarbacaneShot;
    public GameObject gommeShot;
    public Transform throwPoint;
    public string lastFacing;
    public Vector2 wasFacing;
=======
    Animator anim;
>>>>>>> master

    // Use this for initialization
    void Start () {
        offset = gameObject.transform.position + new Vector3(1f, 1f, 0f);
<<<<<<< HEAD
        theRB = GetComponent<Rigidbody2D>();
        instance = this;
=======
        anim = GetComponent<Animator>();
>>>>>>> master
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        SpawnDrawing();
    }

    void Move()
    {

        moveHorizontal1 = Input.GetAxis("HorizontalPlayer1");
        moveVertical1 = Input.GetAxis("VerticalPlayer1");
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizontal1 * speed, moveVertical1 * speed);
<<<<<<< HEAD


        if (moveHorizontal1 > 0)
        {
            faceRight = true;
            faceLeft = false;
            faceUp = false;
            faceDown = false;
            lastFacing = "right";
            wasFacing = new Vector2(moveHorizontal1 + 1-moveHorizontal1, moveVertical1);
        }

        if (moveHorizontal1 < 0)
        {
            faceRight = false;
            faceLeft = true;
            faceUp = false;
            faceDown = false;
            lastFacing = "left";
            wasFacing = new Vector2(moveHorizontal1 - 1+moveHorizontal1, moveVertical1);
        }

        if (moveVertical1 > 0)
        {
            faceRight = false;
            faceLeft = false;
            faceUp = true;
            faceDown = false;
            lastFacing = "up";
            wasFacing = new Vector2(moveHorizontal1, moveVertical1 + 1-moveVertical1);
        }

        if (moveVertical1 < 0)
        {
            faceRight = false;
            faceLeft = false;
            faceUp = false;
            faceDown = true;
            lastFacing = "down";
            wasFacing = new Vector2(moveHorizontal1, moveVertical1 - 1+moveVertical1);
        }


=======
        GetDirection();
>>>>>>> master
    }

    void SpawnDrawing()
    {
        if (tableauHit && Input.GetKey(KeyCode.Joystick1Button0))
        {
            timer -= Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            timer = maxTimer;
        }

        if (timer <= 0)
        {
            Instantiate(ecriture, offset, Quaternion.identity);
            timer = maxTimer;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name ==  "tableau")
        {
            Debug.Log("IN");
            tableauHit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "tableau")
        {
            Debug.Log("OUT");
            tableauHit = false;
        }
    }

    public void GetDirection()
    {
        if (moveHorizontal1 > 0)
        {
            anim.SetBool("faceRight", true);
            anim.SetBool("faceLeft", false);
            anim.SetBool("faceDown", false);
            anim.SetBool("faceUp", false);
        }

        if (moveHorizontal1 < 0)
        {
            anim.SetBool("faceRight", false);
            anim.SetBool("faceLeft", true);
            anim.SetBool("faceDown", false);
            anim.SetBool("faceUp", false);
        }

        if (moveVertical1 > 0)
        {
            anim.SetBool("faceRight", false);
            anim.SetBool("faceLeft", false);
            anim.SetBool("faceDown", false);
            anim.SetBool("faceUp", true);
        }

        if (moveVertical1 < 0)
        {
            anim.SetBool("faceRight", false);
            anim.SetBool("faceLeft", false);
            anim.SetBool("faceDown", true);
            anim.SetBool("faceUp", false);
        }
    }
}
