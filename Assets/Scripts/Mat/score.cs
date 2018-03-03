using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

	public Text Score ;
	public Text High_Score ;
	int NbPoints ;

	void Start () {

		NbPoints = 0;

		High_Score.text = PlayerPrefs.GetInt ("HighScore",0).ToString();

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.name == "vision_cone1") {


			NbPoints++;
			Score.text = NbPoints.ToString();

			if (NbPoints > PlayerPrefs.GetInt ("HighScore")) 
			
			{
				PlayerPrefs.SetInt ("HighScore", NbPoints);
				High_Score.text = NbPoints.ToString ();

			}



		}


	}
}
