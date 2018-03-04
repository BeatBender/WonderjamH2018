using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horloge : MonoBehaviour {
	RectTransform rectTransform;
	float speed;

	// Use this for initialization
	void Start () {
		rectTransform = GetComponent<RectTransform>();
		speed = 0.04f;
	}
	
	// Update is called once per frame
	void Update () {

		rectTransform.Rotate( new Vector3( 0, 0, - speed) );

	}
}
