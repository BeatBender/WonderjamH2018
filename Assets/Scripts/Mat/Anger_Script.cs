using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anger_Script : MonoBehaviour {

	RectTransform rectTransform;
	float max_anger = 180f;
	public static bool Inline;
	public static float Angerlvl;
	 float speed;

	private bool GamePaused;

	// Use this for initialization
	void Start () {

		rectTransform = GetComponent<RectTransform>();
		Angerlvl = 0f;
		Inline = false;
		speed = 0.5f;
		GamePaused = false;
		
	}

	// Update is called once per frame
	void Update () {

		if (Inline == true) {

			rectTransform.Rotate( new Vector3( 0, 0, -speed ) );

			Angerlvl+= speed;
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

		if (Angerlvl >= max_anger)
		{

			PauseGame ();

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
}
