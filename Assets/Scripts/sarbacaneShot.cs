using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class sarbacaneShot : MonoBehaviour
{

	bool isSetted = false;

	private float sarbacaneSpeed = 10f;

	private Rigidbody2D theRB;

	private Vector2 direction;

	private Vector3 orientation;

	private float moveHorizontal1, moveVertical1;




	// Use this for initialization
	void Start()
	{
		Physics2D.IgnoreCollision(GetComponent<Collider2D>(), PlayerController1.instance.GetComponent<Collider2D>());
		theRB = GetComponent<Rigidbody2D>();
		// direction = Vector2.right;
		orientation = transform.rotation.eulerAngles;


		moveHorizontal1 = Input.GetAxis("HorizontalPlayer1");
		moveVertical1 = Input.GetAxis("VerticalPlayer1");

		direction = PlayerController1.instance.wasFacing;
		var angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		var rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = rotation;

		theRB.velocity = direction.normalized * sarbacaneSpeed;

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag != "Player" && coll.gameObject.tag != "Hittable") 
			Destroy (gameObject);


		if (coll.gameObject.tag == "Hittable") {
	//		score.instance.NbPoints += 10;
			Destroy (gameObject);
		}
	}

}
