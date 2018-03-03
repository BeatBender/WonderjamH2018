using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {

    public float speed = 2f;
    private float moveHorizontal2, moveVertical2;
    public GameObject ecriture;
    public Vector3 offset;
    private bool tableauHit;
    private const float maxTimer = 5f;
    private float timer = maxTimer;
    public bool faceRight, faceLeft, faceUp, faceDown;

    // Use this for initialization
    void Start () {
        offset = gameObject.transform.position + new Vector3(1f, 1f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        SpawnDrawing();
    }

    void Move()
    {
        moveHorizontal2 = Input.GetAxis("HorizontalPlayer2");
        moveVertical2 = Input.GetAxis("VerticalPlayer2");
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizontal2 * speed, moveVertical2 * speed);

        if (moveHorizontal2 > 0)
        {
            faceRight = true;
            faceLeft = false;
            faceUp = false;
            faceDown = false;
        }

        if (moveHorizontal2 < 0)
        {
            faceRight = false;
            faceLeft = true;
            faceUp = false;
            faceDown = false;
        }

        if (moveVertical2 > 0)
        {
            faceRight = false;
            faceLeft = false;
            faceUp = true;
            faceDown = false;
        }

        if (moveVertical2 < 0)
        {
            faceRight = false;
            faceLeft = false;
            faceUp = false;
            faceDown = true;
        }
    }

    void SpawnDrawing()
    {
        if (tableauHit && Input.GetKey(KeyCode.Joystick2Button0))
        {
            timer -= Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Joystick2Button0))
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
        if (collision.name == "tableau")
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
}
