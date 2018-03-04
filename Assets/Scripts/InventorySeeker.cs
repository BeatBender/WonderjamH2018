using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySeeker : MonoBehaviour {
	public string nameInventory;
	public GameObject Inventory;
	// Use this for initialization
	void Start () {
		Inventory = GameObject.Find (nameInventory);
		Inventory.transform.SetParent (this.gameObject.transform, false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
