using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class eraserShot : MonoBehaviour {

    bool isSetted = false;

    public float eraserSpeed = 10f;

    private Rigidbody2D theRB;

    private Vector2 direction;

	// Use this for initialization
	void Start () {
        theRB = GetComponent<Rigidbody2D>();
        direction = Vector2.right;
	}

    void FixedUpdate()
    {
        if (isSetted == false)
        {
            if (playerManager.instance.lastFacing == "right")
            {
                direction = new Vector2(1, 0);
                isSetted = true;
            }

            if (playerManager.instance.lastFacing == "left")
            {
                direction = new Vector2(-1, 0);
                isSetted = true;
            }

            if (playerManager.instance.lastFacing == "down")
            {
                direction = new Vector2(0, -1);
                isSetted = true;
            }

            if (playerManager.instance.lastFacing == "up")
            {
                direction = new Vector2(0, 1);
                isSetted = true;
            }

            theRB.velocity = direction * eraserSpeed;
        }
    }

	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
