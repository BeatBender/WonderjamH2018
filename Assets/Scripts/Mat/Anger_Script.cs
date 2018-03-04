using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anger_Script : MonoBehaviour {

	RectTransform rectTransform;
	float max_anger;
	public static bool Inline;
	public static float Angerlvl;
	float speed;


	private bool GamePaused;
	public GameObject GameOver;

	// Use this for initialization
	void Start () {

		rectTransform = GetComponent<RectTransform>();
		Angerlvl = 90f;
		Inline = false;
		speed = 0.1f;
		GamePaused = false;
		 max_anger = 22f;
		GameOver.SetActive (false);
		
	}

	// Update is called once per frame
	void Update () {

		if (Inline == true & GamePaused == false) {

			rectTransform.Rotate( new Vector3( 0, 0, -speed ) );

			Angerlvl-= speed;
			Debug.Log (Angerlvl);
		}



		if(Input.GetKeyDown(KeyCode.Escape) ){
			if(!GamePaused){  
				PauseGame ();
			}
			else{
				ResumeGame ();
			}
		}

		if (Angerlvl <= max_anger)
		{

			Game_Over();

		}



	


	}

	void OnGUI()
	{
		if (GamePaused)
		{

			if (GUI.Button (new Rect (Screen.width / 2 - 40, Screen.height / 2 - 100, 150, 100), "Continuer"))
			
			{
				ResumeGame ();
			}


			if (GUI.Button (new Rect (Screen.width / 2 - 40, Screen.height / 2 +100, 150, 100), "Quitter"))

			{
				Application.Quit ();
			}
		}



	}

	private void PauseGame()
	{
		Time.timeScale = 0f;
		GamePaused = true;
		//Disable scripts that still work while timescale is set to 0
	} 



	private void ResumeGame()
	{
		Time.timeScale = 1f;
		GamePaused = false;
		//Disable scripts that still work while timescale is set to 0
	}


	private void Game_Over()
	{
		GamePaused = true;
		GameOver.SetActive (true);
		Time.timeScale = 0f;


	}
}
