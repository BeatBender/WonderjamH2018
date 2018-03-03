using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 2f;
    private float moveHorizontal, moveVertical;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = Color.black;

        Debug.Log("lol");
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        Debug.Log("lel");
    }

    void Move()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(moveHorizontal * speed, 0f, moveVertical * speed);
    }
}
