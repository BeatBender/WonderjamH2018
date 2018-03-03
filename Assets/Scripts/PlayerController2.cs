using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {

    public float speed = 2f;
    private float moveHorizontal2, moveVertical2;
    public GameObject ecriture;
    public Transform offset;
    private bool tableauHit;
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
        moveHorizontal2 = Input.GetAxis("HorizontalPlayer2");
        moveVertical2 = Input.GetAxis("VerticalPlayer2");
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizontal2 * speed, moveVertical2 * speed);
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
            Instantiate(ecriture, offset);
            timer = maxTimer;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "tableau")
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
