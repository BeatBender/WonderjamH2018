using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour {

    public float speed = 2f;
    private float moveHorizontal1, moveVertical1;
    public GameObject ecriture;
    public Transform offset;
    private bool tableauHit = false;
    private const float maxTimer = 5f;
    private float timer = maxTimer;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Renderer>().material.color = Color.black;
        offset.position = gameObject.transform.position + new Vector3(1f, 1f, 0f);
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
            Instantiate(ecriture, offset);
            timer = maxTimer;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.name ==  "tableau")
        {
            tableauHit = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.name == "tableau")
        {
            tableauHit = false;
        }
    }
}
