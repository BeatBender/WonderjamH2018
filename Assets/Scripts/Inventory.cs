using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	private struct Object{

		private int id;//1 = Bombe ; 2 = Stylo ; 3 = Sarbacane
		private int quantity; 
		}

	private Object[] player_Inventory; 

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	// Use this for initialization
	void Start () {
		this.player_Inventory = new Object[]{}; 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("") != 0) {
		
		} else {
			DisplaySelector ();
		}
	}

	void UpdateSelector(int change){
		
	}

	void DisplaySelector(){
		
	}


}
