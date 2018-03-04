using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horloge : MonoBehaviour {
	RectTransform rectTransform;
	float speed;
	float rotation;



	// Use this for initialization
	void Start () {


//		GameObject anger = GameObject.Find("AnchorEguille");
//
//	
//		anger. other = (ScriptB) go.GetComponent(typeof(ScriptB));
//		other.DoSomething();
		speed = 0.04f;
	}
	
	// Update is called once per frame
	void Update () {


		if (rotation >= 360) {


		}
		rectTransform.Rotate( new Vector3( 0, 0, - speed) );



	}



}
