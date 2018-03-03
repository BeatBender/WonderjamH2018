using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSelectionMenu_Gamemode : MonoBehaviour {

		// Use this for initialization
	public RectTransform selector1; 
	public int select1Pos = 0;
	public RectTransform selector2; 
	public int select2Pos= 0;

	public int numberObject ; 
	public RectTransform[] slots;
	public int jumpAmount ;

	public Text textShowSelect1;
	public Text textShowSelect2;

	void Start () {
		jumpAmount = numberObject / 4;
		slots = new RectTransform[numberObject];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("VerticalPlayer1") !=0) {
			if (numberObject < 4) {
				select1Pos = (int)Input.GetAxis ("VerticalPlayer1") *4 * jumpAmount;
			} else {
				select1Pos = select1Pos; 
			}
		}
		if (Input.GetAxis ("VerticalPlayer2")!=0) {
			if (numberObject < 4) {
				select2Pos = (int) Input.GetAxis ("VerticalPlayer1") * 4 * jumpAmount;
			} else {
				select2Pos = select2Pos;
			}
		}
		if (Input.GetAxis ("HorizontalPlayer1")!=0) {
			select1Pos += (int)Input.GetAxis ("VerticalPlayer1") *4 * jumpAmount;
			}
		if (Input.GetAxis ("HorizontalPlayer2")!=0) {
		
			select2Pos = (int)Input.GetAxis ("VerticalPlayer1") * 4 * jumpAmount;
		}

	
		
		
	}
}
