using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	private struct Object{

		public int id; //1 = Bombe ; 2 = Stylo ; 3 = Sarbacane
		public int quantity; 
		}

	private Object[] player_Inventory; 

	public GameObject []InventorySlotsSkin;
	private GameObject []Slots;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	// Use this for initialization
	void Start () {
		this.player_Inventory = new Object[]{}; 
		Vector3 spawnPosition = new Vector3 (0, 0, 0);
		Quaternion spawnRotation = Quaternion.identity;
		Slots = new GameObject[3];
		int[] position_Y = new int[]{-35,-45,-35};
		int[] position_X = new int[]{-20,0,20};


		for(int i = 0; i < 3; i++){
			Slots[i] = Instantiate (InventorySlotsSkin[i], spawnPosition, spawnRotation) as GameObject;
			Slots [i].transform.SetParent (this.gameObject.transform, false);
			Slots [i].transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.0f);
			Slots [i].transform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.0f);
			Slots [i].transform.localScale = new Vector3 (0.15f, 0.15f, 0.15f);
			Slots [i].transform.TransformVector(spawnPosition);
			Slots [i].transform.localPosition = new Vector3(position_X[i], position_Y[i], 1);

		}
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
