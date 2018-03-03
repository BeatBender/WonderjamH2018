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

	void Start () {
		jumpAmount = numberObject / 4;
		slots = new RectTransform[numberObject];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("VerticalPlayer1") !=0) {
				MoveSelect1((int)Input.GetAxis ("VerticalPlayer1") *4 * jumpAmount);
		}
		if (Input.GetAxis ("VerticalPlayer2")!=0) {
				MoveSelect2((int) Input.GetAxis ("VerticalPlayer1") * 4 * jumpAmount);
		}
		if (Input.GetAxis ("HorizontalPlayer1")!=0) {
			MoveSelect1((int)Input.GetAxis ("VerticalPlayer1"));
		}
		if (Input.GetAxis ("HorizontalPlayer2")!=0) {
			MoveSelect2((int)Input.GetAxis ("VerticalPlayer1"));
		}
	}

	void MoveSelect1(int change){
		if (change > 0) {
			if (select1Pos + change < slots.Length - 1) {
				select1Pos += change; 
			} else {
				select1Pos = slots.Length - 1;
			}
		} else {
			if (select1Pos + change >= 0) {
				select1Pos += change;
			} else {
				select1Pos = 0;
			}
		}
		selector1.position = slots [select1Pos].position;
	}
	void MoveSelect2(int change){
		if (change > 0) {
			if (select2Pos + change < slots.Length - 1) {
				select2Pos += change; 
			} else {
				select2Pos = slots.Length - 1;
			}
		} else {
			if (select2Pos + change >= 0) {
				select2Pos += change;
			} else {
				select2Pos = 0;
			}
		}
		selector2.position = slots [select1Pos].position;
	}
}
