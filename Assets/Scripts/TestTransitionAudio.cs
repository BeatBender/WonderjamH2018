using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTransitionAudio : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("1") || Input.GetKeyDown(KeyCode.Keypad1))
            MusiqueMenu();

        if (Input.GetKeyDown("2") || Input.GetKeyDown(KeyCode.Keypad2))
            Musique2();

        if (Input.GetKeyDown("3") || Input.GetKeyDown(KeyCode.Keypad3))
            CheckPlayer();

        if (Input.GetKeyDown("4") || Input.GetKeyDown(KeyCode.Keypad4))
            Seek();

        if (Input.GetKeyDown("5") || Input.GetKeyDown(KeyCode.Keypad5))
            Perdu();

        if (Input.GetKeyDown("6") || Input.GetKeyDown(KeyCode.Keypad6))
            Victoire();

    }

    void MusiqueMenu() {
        if (FindObjectOfType<AudioManager>() != null) {
            FindObjectOfType<AudioManager>().A_MusiqueMenu();
        }
    }

    void Musique2() {
        if (FindObjectOfType<AudioManager>() != null) {
            FindObjectOfType<AudioManager>().A_Musique2();
        }
    }

    void CheckPlayer() {
        if (FindObjectOfType<AudioManager>() != null) {
            FindObjectOfType<AudioManager>().A_CheckPlayer();
        }
    }

    void Seek() {
        if (FindObjectOfType<AudioManager>() != null) {
            FindObjectOfType<AudioManager>().A_Seek();
        }
    }

    void Perdu() {
        if (FindObjectOfType<AudioManager>() != null) {
            FindObjectOfType<AudioManager>().A_Perdu();
        }
    }

    void Victoire() {
        if (FindObjectOfType<AudioManager>() != null) {
            FindObjectOfType<AudioManager>().A_Victoire();
        }
    }
}
