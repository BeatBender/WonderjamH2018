using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class eraserShot : MonoBehaviour {

	bool isSetted = false;

	public float eraserSpeed = 10f;

	private Rigidbody2D theRB;

	private Vector2 direction;

	private float moveHorizontal1, moveVertical1;

	// Use this for initialization
	void Start () {

		Physics2D.IgnoreCollision(GetComponent<Collider2D>(), PlayerController1.instance.GetComponent<Collider2D>());
		theRB = GetComponent<Rigidbody2D>();
		direction = Vector2.right;
	}

	void FixedUpdate()
	{
		moveHorizontal1 = Input.GetAxis("HorizontalPlayer1");
		moveVertical1 = Input.GetAxis("VerticalPlayer1");

		if (isSetted == false)
		{
			direction = PlayerController1.instance.wasFacing;
			theRB.velocity = direction * eraserSpeed;
			isSetted = true;
		}
	}


	// Update is called once per frame
	void Update ()
	{

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag != "Player")
			Destroy(gameObject);

	}
}
