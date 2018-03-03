using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Featureecriretableau : MonoBehaviour {

    public GameObject ecriture;
    private Vector3 offset;
    public GameObject player1;
    public GameObject player2;

	// Use this for initialization
	void Start () {
        offset = new Vector3(1f, 1f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("Space"))
        {
            //Instantiate(ecriture, (player1.transform.position + offset));
        }
	}
}
