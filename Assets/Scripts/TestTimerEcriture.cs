using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimerEcriture : MonoBehaviour {

    //private int counter;
    private const float maxTimer = 5f;
    private float timer = maxTimer;

	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey(KeyCode.Space))
        {
            timer -= Time.deltaTime;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            timer = maxTimer;
        }
        
        if(timer <= 0)
        {
            Debug.Log(timer);
            timer = maxTimer;
        }
    }
}
