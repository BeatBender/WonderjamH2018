using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectSelectionMenu_Gamemode : MonoBehaviour {

    public RectTransform navigator1;
    int nav1Pos = 0;
    public RectTransform navigator2;
    int nav2Pos = 0;
 
	public RectTransform[] slots = new RectTransform[3];
    public RectTransform[] slotJ1 = new RectTransform[3];
	private int objectJ1;
    private int objectJ2;
	public RectTransform[] slotJ2 = new RectTransform[3];
	public int jumpAmount;
	public float timeToWaitJ1, timeToWaitJ2;
	private float waitingTime;

	public RawImage[] objectPlaceJ1 = new RawImage[3];
	public RawImage[] objectPlaceJ2 = new RawImage[3];

	public RawImage[] imageObject= new RawImage[3];
    
	void Start(){
    	MoveNav1(0);
  	    MoveNav2(0);
		timeToWaitJ1 = (float)0.3;
		timeToWaitJ2 = (float)0.3;
		waitingTime = timeToWaitJ1;
		timeToWaitJ1 = 0;
		timeToWaitJ2 = 0;
	}

     void Update () {
         // move up
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
					objectPlaceJ1 [objectJ1] = (RawImage)Instantiate<RawImage>(imageObject[0]) as RawImage ;
					objectPlaceJ1[objectJ1] = imageObject [0];
					objectPlaceJ1 [objectJ1].uvRect.Set (slotJ1 [0].position.x, slotJ1 [0].position.y, 0.3f, 0.3f);
				}
				break;
			case 1:
				{
					objectPlaceJ1 [objectJ1] = imageObject [1];
					objectPlaceJ1 [objectJ1].uvRect.Set (slotJ1 [1].position.x, slotJ1 [1].position.y, 0.3f, 0.3f);
				}
				break;
			case 2:
				{
					objectPlaceJ1 [2] = imageObject [2];
					objectPlaceJ1 [2].uvRect.Set (slotJ1 [2].position.x, slotJ1 [2].position.y, 0.3f, 0.3f);
				}
				break;
			}
		}
		if (Input.GetKeyDown (KeyCode.Joystick2Button0)) {
//			switch (nav2Pos) {
//			case 0:
//				slotJ2[objectJ2] = new RectTransform (slots [0]);
//				break;
//			case 1:
//				slotJ2[objectJ2] = new RectTransform (slots [1]);
//			case 2:
//				slotJ2[objectJ2] = new RectTransform (slots [2]);
//				}
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
 