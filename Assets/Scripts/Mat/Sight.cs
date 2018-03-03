using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}




	void OnTriggerStay2D(Collider2D other) {

		if (other.name == "PlayerTemp") {

			Debug.Log ("Hit");

			Anger_Script.Inline = true;


		}
	}



	void OnTriggerExit2D(Collider2D other) {

		if (other.name == "PlayerTemp") {

			Debug.Log ("Hit");

			Anger_Script.Inline = false;


		}
	}
}
