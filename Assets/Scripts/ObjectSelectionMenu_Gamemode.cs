using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectSelectionMenu_Gamemode : MonoBehaviour {

	public RectTransform navigator1;
	int nav1Pos = 0;
	public RectTransform navigator2;
	int nav2Pos = 0;

	public Inventory P1Inventory;
	public Inventory P2Inventory;
	public RectTransform[] slots = new RectTransform[3];
	public RectTransform[] slotJ1 = new RectTransform[3];
	private int objectJ1;
	private int objectJ2;
	public RectTransform[] slotJ2 = new RectTransform[3];
	public int jumpAmount;
	public float timeToWaitJ1, timeToWaitJ2;
	private float waitingTime;
	private int[] idItemJ1 = new int[3];
	private int[] idItemJ2 = new int [3];

	public GameObject SceneNext; 

	public GameObject parentInCanvasJ1, parentInCanvasJ2;

	private GameObject[] objectPlaceJ1 = new GameObject[3] ;
	private GameObject[] objectPlaceJ2 = new GameObject[3];

	public GameObject[] imageObject= new GameObject[3];

	void Start(){
		MoveNav1(0);
		MoveNav2(0);
		timeToWaitJ1 = (float)0.5;
		timeToWaitJ2 = (float)0.5;
		waitingTime = timeToWaitJ1;
		timeToWaitJ1 = 0;
		timeToWaitJ2 = 0;
		objectJ1 = 0;
		objectJ2 = 0;
	}

	void Update () {
		// move up
		if(objectJ1 == 3 && objectJ2 == 3 && Input.GetKeyDown(KeyCode.JoystickButton7)){
			
		}

		if(Input.GetAxis("VerticalPlayer1") != 0 && timeToWaitJ1 <= 0 ){
			timeToWaitJ1 = waitingTime;
			MoveNav1((float)-jumpAmount * Input.GetAxis("VerticalPlayer1"));
		}
		if(Input.GetAxis("VerticalPlayer2")!= 0 && timeToWaitJ2 <= 0 ){
			timeToWaitJ2 = waitingTime;
			MoveNav2((float)-jumpAmount *  Input.GetAxis("VerticalPlayer2"));
		}

		if(Input.GetAxis("HorizontalPlayer1")!= 0 && timeToWaitJ1 <=0.0f ){
			timeToWaitJ1 = waitingTime;
			MoveNav1(Input.GetAxis("HorizontalPlayer1"));
		}
		if(Input.GetAxis("HorizontalPlayer2")!= 0 &&  timeToWaitJ2 <= 0.0f ){
			timeToWaitJ2 = waitingTime;
			MoveNav2(Input.GetAxis("HorizontalPlayer2"));
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button0) && objectJ1 < 3) {
			switch (nav1Pos) {
			case 0:
				{
					Vector3 spawnPosition = new Vector3 (0, 0, 0);
					Quaternion spawnRotation = Quaternion.identity;
					objectPlaceJ1[objectJ1] = Instantiate (imageObject [0], spawnPosition, spawnRotation) as GameObject;
					objectPlaceJ1 [objectJ1].transform.SetParent (parentInCanvasJ1.transform, false);
					objectPlaceJ1 [objectJ1].transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
					objectPlaceJ1 [objectJ1].transform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
					objectPlaceJ1 [objectJ1].transform.localScale = new Vector3 (0.3f, 0.2f, 1);
					objectPlaceJ1 [objectJ1].transform.position = new Vector3 (slotJ1 [objectJ1].position.x, slotJ1 [objectJ1].position.y, slotJ1 [objectJ1].position.z	);
					P1Inventory.AddItem (0, 1);
					idItemJ1 [objectJ1] = 0;
					objectJ1++;
				}
				break;
			case 1:
				{
					Vector3 spawnPosition = new Vector3 (0, 0, 0);
					Quaternion spawnRotation = Quaternion.identity;
					objectPlaceJ1[objectJ1] = Instantiate (imageObject [1], spawnPosition, spawnRotation) as GameObject;
					objectPlaceJ1 [objectJ1].transform.SetParent (parentInCanvasJ1.transform, false);
					objectPlaceJ1 [objectJ1].transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
					objectPlaceJ1 [objectJ1].transform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
					objectPlaceJ1 [objectJ1].transform.localScale = new Vector3 (0.3f, 0.2f, 1);
					objectPlaceJ1 [objectJ1].transform.position = new Vector3 (slotJ1 [objectJ1].position.x, slotJ1 [objectJ1].position.y, slotJ1 [objectJ1].position.z	);
					idItemJ1 [objectJ1] = 1;
					P1Inventory.AddItem (1, 1);
					objectJ1++;
				}
				break;
			case 2:
				{
					Vector3 spawnPosition =  new Vector3 (0, 0, 0);
					Quaternion spawnRotation = Quaternion.identity;
					objectPlaceJ1[objectJ1] = Instantiate (imageObject [2], spawnPosition, spawnRotation) as GameObject;
					objectPlaceJ1 [objectJ1].transform.SetParent (parentInCanvasJ1.transform, false);
					objectPlaceJ1 [objectJ1].transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
					objectPlaceJ1 [objectJ1].transform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
					objectPlaceJ1 [objectJ1].transform.localScale = new Vector3 (0.3f, 0.2f, 1);
					objectPlaceJ1 [objectJ1].transform.position = new Vector3 (slotJ1 [objectJ1].position.x, slotJ1 [objectJ1].position.y, slotJ1 [objectJ1].position.z	);
					idItemJ1 [objectJ1] = 2;
					P1Inventory.AddItem (2, 1);
					objectJ1++;
				}
				break;
			}
		}
		if (Input.GetKeyDown (KeyCode.Joystick2Button0)&& objectJ2 < 3) {
			switch (nav2Pos) {
			case 0:
				{
					Vector3 spawnPosition = new Vector3(0, 0, 0);
					Quaternion spawnRotation = Quaternion.identity;
					objectPlaceJ2[objectJ2] = Instantiate (imageObject [0], spawnPosition, spawnRotation) as GameObject;
					objectPlaceJ2 [objectJ2].transform.SetParent (parentInCanvasJ2.transform, false);
					objectPlaceJ2 [objectJ2].transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
					objectPlaceJ2 [objectJ2].transform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
					objectPlaceJ2 [objectJ2].transform.localScale = new Vector3 (0.3f, 0.2f, 1);
					objectPlaceJ2 [objectJ2].transform.position = new Vector3 (slotJ2 [objectJ2].position.x, slotJ2 [objectJ2].position.y, slotJ2 [objectJ2].position.z	);
					idItemJ2 [objectJ2] = 0;
					P2Inventory.AddItem (0, 1);
					objectJ2++;
				}
				break;
			case 1:
				{
					Vector3 spawnPosition = new Vector3 (0, 0, 0);
					Quaternion spawnRotation = Quaternion.identity;
					objectPlaceJ2[objectJ2] = Instantiate (imageObject [1], spawnPosition, spawnRotation) as GameObject;
					objectPlaceJ2 [objectJ2].transform.SetParent (parentInCanvasJ2.transform, false);
					objectPlaceJ2 [objectJ2].transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
					objectPlaceJ2 [objectJ2].transform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
					objectPlaceJ2 [objectJ2].transform.localScale = new Vector3 (0.3f, 0.2f, 1);
					objectPlaceJ2 [objectJ2].transform.position = new Vector3 (slotJ2 [objectJ2].position.x, slotJ2 [objectJ2].position.y, slotJ2 [objectJ2].position.z	);
					idItemJ2 [objectJ2] = 1;
					P2Inventory.AddItem (1, 1);
					objectJ2++;
				}
				break;
			case 2:
				{
					Vector3 spawnPosition =  new Vector3 (0, 0, 0);
					Quaternion spawnRotation = Quaternion.identity;
					objectPlaceJ2[objectJ2] = Instantiate (imageObject [2], spawnPosition, spawnRotation) as GameObject;
					objectPlaceJ2 [objectJ2].transform.SetParent (parentInCanvasJ2.transform, false);
					objectPlaceJ2 [objectJ2].transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
					objectPlaceJ2 [objectJ2].transform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
					objectPlaceJ2 [objectJ2].transform.localScale = new Vector3 (0.3f, 0.2f, 1);
					objectPlaceJ2 [objectJ2].transform.position = new Vector3 (slotJ2 [objectJ2].position.x, slotJ2 [objectJ2].position.y, slotJ2 [objectJ2].position.z	);
					idItemJ2 [objectJ2] = 2;
					P2Inventory.AddItem (2, 1);
					objectJ2++;
				}
				break;
			}}

		if (Input.GetKeyDown (KeyCode.Joystick1Button1) && objectJ1 >0) {
			Destroy(objectPlaceJ1 [objectJ1-1]);
			P1Inventory.RemoveItem (idItemJ1 [objectJ1 - 1]);
			objectJ1--;
		}

		if (Input.GetKeyDown (KeyCode.Joystick2Button1) && objectJ2 >0) {
			Destroy(objectPlaceJ2 [objectJ2-1]);
			P2Inventory.RemoveItem (idItemJ2 [objectJ2 - 1]);
			objectJ2--;
		}

		float temp = Time.deltaTime;
		timeToWaitJ1 -= temp;
		timeToWaitJ2 -= temp;
	}

	void MoveNav1(float change){
		if(change > 0){
			if(nav1Pos+1 < slots.Length-1){
				nav1Pos += 1;
			}else{
				nav1Pos = slots.Length-1;
			}
		}else{
			if(nav1Pos-1 >= 0){
				nav1Pos += -1;
			}else{
				nav1Pos = 0;
			}
		}
		navigator1.position = slots[nav1Pos].position;
	}

	void MoveNav2(float change){
		if(change > 0){
			if(nav2Pos+1 < slots.Length-1){
				nav2Pos += 1;
			}else{
				nav2Pos = slots.Length-1;
			}
		}else{
			if(nav2Pos-1 >= 0){
				nav2Pos += -1;
			}else{
				nav2Pos = 0;
			}
		}
		navigator2.position = slots[nav2Pos].position;
	}
}

 