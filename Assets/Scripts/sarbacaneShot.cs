using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class sarbacaneShot : MonoBehaviour
{

    bool isSetted = false;

    public float sarbacaneSpeed = 10f;

    private Rigidbody2D theRB;

    private Vector2 direction;

    private Vector3 orientation;

    // Use this for initialization
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        direction = Vector2.right;
        orientation = transform.rotation.eulerAngles;
    }

    void FixedUpdate()
    {
        if (isSetted == false)
        {

            if (playerManager.instance.lastFacing == "right")
            {
                orientation.z = -90;
                transform.rotation = Quaternion.Euler(orientation);
                direction = new Vector2(1, 0);
                isSetted = true;
            }

            if (playerManager.instance.lastFacing == "left")
            {
                orientation.z = 90;
                transform.rotation = Quaternion.Euler(orientation);
                direction = new Vector2(-1, 0);
                isSetted = true;
            }

            if (playerManager.instance.lastFacing == "down")
            {
                orientation.z = 180;
                transform.rotation = Quaternion.Euler(orientation);
                direction = new Vector2(0, -1);
                isSetted = true;
            }

            if (playerManager.instance.lastFacing == "up")
            {
                orientation.z = 0;
                transform.rotation = Quaternion.Euler(orientation);
                direction = new Vector2(0, 1);
                isSetted = true;
            }

            theRB.velocity = direction * sarbacaneSpeed;
        }
        
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
