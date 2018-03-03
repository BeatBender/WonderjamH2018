using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	private struct Object{
<<<<<<< HEAD
		//private int id { get; }
		//private int quantity { get;} 
=======
		private int id;
		private int quantity; 
>>>>>>> refs/remotes/origin/Inventory_Feature
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
