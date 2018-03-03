using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {

    public float speed = 2f;
    private float moveHorizontal2, moveVertical2;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = Color.black;       
    }
	
	// Update is called once per frame
	void Update () {
        Move();
    }

    void Move()
    {
        moveHorizontal2 = Input.GetAxis("HorizontalPlayer2");
        moveVertical2 = Input.GetAxis("VerticalPlayer2");
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizontal2 * speed, moveVertical2 * speed);
    }
}
