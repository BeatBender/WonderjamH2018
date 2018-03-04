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
	public GameObject[] ObjectSkin;
	private GameObject []Slots;
	private GameObject[] ActuelDisplayItem;
	private int []idCollection;

	private float opacity = 1.0f;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	// Use this for initialization
	void Start () {
		this.ActuelDisplayItem= new GameObject[]{};
		this.player_Inventory = new Object[]{}; 
		Vector3 spawnPosition = new Vector3 (0, 0, 0);
		Quaternion spawnRotation = Quaternion.identity;
		this.Slots = new GameObject[3];
		int[] position_Y = new int[]{-35,-45,-35};
		int[] position_X = new int[]{-20,0,20};
		this.idCollection = new int[]{ 0, 1, 2 };


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

		opacity -= 0.1f;
		Color tempCol;
		tempCol = this.Slots [0].GetComponent<Renderer> ().material.color;
		tempCol.a = opacity;
		this.Slots [0].GetComponent<Renderer> ().material.color = tempCol;
		tempCol = this.Slots [2].GetComponent<Renderer> ().material.color;
		tempCol.a = opacity;
		this.Slots [2].GetComponent<Renderer> ().material.color = tempCol;
	}
		
	public void AddItem(int objet, int qt){
		for (int i = 0; i < this.player_Inventory.Length; i++) {
			if (this.player_Inventory [i].id == objet) {
				this.player_Inventory [i].quantity = qt; 
				i = this.player_Inventory.Length;
			} else {
				this.ActuelDisplayItem [this.player_Inventory.Length] = this.ObjectSkin[objet];
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

	public void UpdateSelector(bool droite){
		opacity = 1.0f;
		Color tempCol;
		for(int i = 0; i < 3; i++){
			tempCol = this.Slots [i].GetComponent<Renderer> ().material.color;
			tempCol.a = opacity;
			this.Slots [i].GetComponent<Renderer> ().material.color = tempCol;
	}
		if (!droite) {

			GameObject temp = this.ActuelDisplayItem [1];
			GameObject temp2 = this.ActuelDisplayItem [2];
			int tempId = this.idCollection[1];
			int temp2Id = this.idCollection[2];
			this.ActuelDisplayItem [1] = this.ActuelDisplayItem [0];
			this.idCollection [1] = this.idCollection [0];
			this.idCollection [2] = tempId;
			this.idCollection [0] = temp2Id;
			this.ActuelDisplayItem [2] = temp;
			this.ActuelDisplayItem [0] = temp2;
		}else {
			GameObject temp = this.ActuelDisplayItem [0];
			GameObject temp2 = this.ActuelDisplayItem [1];
			int tempId = this.idCollection[0];
			int temp2Id = this.idCollection[1];
			this.ActuelDisplayItem [1] = this.ActuelDisplayItem [2];
			this.ActuelDisplayItem [0] = temp;
			this.ActuelDisplayItem [2] = temp2;
			this.idCollection [1] = this.idCollection [2];
			this.idCollection [0] = tempId;
			this.idCollection [2] = temp2Id;
		}
}
	public void UpdateSelector (){
		this.ActuelDisplayItem [1] = this.ActuelDisplayItem [2];
		this.ActuelDisplayItem [2] = this.ActuelDisplayItem [0];
		this.idCollection [1] = this.idCollection [2];
		this.idCollection [2] = this.idCollection [0];
	}

	public int GetActualObject ()
	{
		for (int i = 0; i < this.player_Inventory.Length; i++) {
			if (this.player_Inventory [i].id == this.idCollection [2]) {
				{
					return this.player_Inventory [i].id;
				}
			}
		} 
				return 4;
		
	
		}
	}