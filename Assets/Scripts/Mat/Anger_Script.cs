using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anger_Script : MonoBehaviour {

	RectTransform rectTransform;
	float max_anger = 180f;
	public static bool Inline;
	public static float Angerlvl;
	 float speed;

	// Use this for initialization
	void Start () {

		rectTransform = GetComponent<RectTransform>();
		Angerlvl = 0f;
		Inline = false;
		speed = 0.5f;
		
	}

	// Update is called once per frame
	void Update () {

		if (Inline == true) {

			rectTransform.Rotate( new Vector3( 0, 0, -speed ) );

			Angerlvl+= speed;
			Debug.Log (Angerlvl);
		}



	}
}
