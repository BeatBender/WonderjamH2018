using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

	public Text Score ;
	public Text High_Score ;
<<<<<<< HEAD
	public int NbPoints ;
	private float time = 0.0f;
	public float interpolationPeriod = 0.5f;
	public static score instance;


=======
	int NbPoints ;
>>>>>>> origin/feature_feedbacks

	void Start () {
		instance = this;

		NbPoints = 0;

		High_Score.text = PlayerPrefs.GetInt ("HighScore",0).ToString();

	}
	
	// Update is called once per frame
	void Update () {
		NbPoints++;

		Score.text = NbPoints.ToString();

		if (NbPoints > PlayerPrefs.GetInt ("HighScore")) 

		{
			PlayerPrefs.SetInt ("HighScore", NbPoints);
			High_Score.text = NbPoints.ToString ();

		}
		
	}


	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.name == "vision_cone1") {


			//NbPoints++;




		}


	}
}
