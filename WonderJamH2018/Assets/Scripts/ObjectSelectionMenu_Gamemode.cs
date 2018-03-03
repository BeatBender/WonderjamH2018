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

	public int numberObject; 
	public RectTransform[] slots = new RectTransform[numberObject];


	public Text textShowSelect1;
	public Text textShowSelect2;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
