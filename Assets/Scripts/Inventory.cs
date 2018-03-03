using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	private struct Object{

		public int id; //1 = Bombe ; 2 = Stylo ; 3 = Sarbacane
		public int quantity; 
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
		if (Input.GetKeyDown (KeyCode.Joystick1Button4)) {
			//left1
		}
		if (Input.GetKeyDown (KeyCode.Joystick2Button4)) {
			//left2	
		}if (Input.GetKeyDown (KeyCode.Joystick1Button5)) {
			//right1	
		}if (Input.GetKeyDown (KeyCode.Joystick2Button5)) {
			//right2
		} 

	}
		
	public void AddItem(int objet, int qt){
		for (int i = 0; i < this.player_Inventory.Length; i++) {
			if (this.player_Inventory [i].id == objet) {
				this.player_Inventory [i].quantity = qt; 
				i = this.player_Inventory.Length;
			}
		}
	}

	public void RemoveItem(int objet){
		for (int i = 0; i < this.player_Inventory.Length; i++) {
			if (this.player_Inventory [i].id == objet) {
				this.player_Inventory [i].quantity -= 1; 
				i = this.player_Inventory.Length ;
			}
		}
	}

	void UpdateSelector(int change){
		
	}

	void DisplaySelector(){
		
	}


}
