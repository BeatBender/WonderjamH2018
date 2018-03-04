using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gettingGrabbed : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player" && gameObject.tag == "eraser")
        {
            Debug.Log("collision");
            objectsManager.instance.numberEraser += 1;
            Destroy(gameObject);
        }

        if (coll.gameObject.tag == "Player" && gameObject.tag == "sarbacane")
        {
            Debug.Log("collision");
            objectsManager.instance.numberSarbacane += 1;
            Destroy(gameObject);
        }

        if (coll.gameObject.tag == "Player" && gameObject.tag == "paperBoom")
        {
            Debug.Log("collision");
            objectsManager.instance.numberPaperBoom += 1;
            Destroy(gameObject);
        }

        if (coll.gameObject.tag == "Player" && gameObject.tag == "boulePuante")
        {
            Debug.Log("collision");
            objectsManager.instance.numberBoulePuante += 1;
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	//void Update ()
 //   {



		
	//}
}
