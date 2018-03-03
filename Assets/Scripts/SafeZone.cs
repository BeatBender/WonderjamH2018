using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour {

    bool isPlayer1Safe, isPlayer2Safe;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player1")
        {
            isPlayer1Safe = true;
        }

        if (collision.name == "Player2")
        {
            Debug.Log("Safe");
            isPlayer2Safe = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player1")
        {
            isPlayer1Safe = false;
        }

        if (collision.name == "Player2")
        {
            Debug.Log("Not Safe");
            isPlayer2Safe = false;
        }
    }
}
