using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour {

    public float speed = 2f;
    private float moveHorizontal1, moveVertical1;
    public GameObject ecriture;
    public Transform offset;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Renderer>().material.color = Color.black;
        offset.position = gameObject.transform.position + new Vector3(1f, 1f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Instantiate(ecriture, offset);
        }
    }

    void Move()
    {
        moveHorizontal1 = Input.GetAxis("HorizontalPlayer1");
        moveVertical1 = Input.GetAxis("VerticalPlayer1");
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizontal1 * speed, moveVertical1 * speed);
    }
}
