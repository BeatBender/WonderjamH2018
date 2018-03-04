using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectsManager : MonoBehaviour {

    
    public static objectsManager instance;
    public int numberEraser = 0;
    public int numberSarbacane = 0;
    public int numberPaperBoom = 0;
    public int numberBoulePuante = 0;

    public int weaponNumber;

    public KeyCode shoot;

    public bool isShooting;



    // Use this for initialization
    void Start ()
    {
        weaponNumber = 1;
        instance = this;
	}


    public void throwWeapon()
    {
        if (numberEraser > 0 && weaponNumber == 1)
        {
            Instantiate(playerManager.instance.gommeShot, playerManager.instance.throwPoint.position, playerManager.instance.throwPoint.rotation);
            numberEraser -= 1;
        }

        if (numberSarbacane > 0 && weaponNumber == 2)
        {
            Instantiate(playerManager.instance.sarbacaneShot, playerManager.instance.throwPoint.position, playerManager.instance.throwPoint.rotation);
            numberSarbacane -= 1;
        }

    }

    public void throwEraser()
    {
        if (numberEraser > 0 && weaponNumber == 1)
        {
            Instantiate(playerManager.instance.gommeShot, playerManager.instance.throwPoint.position, playerManager.instance.throwPoint.rotation);
            numberEraser -= 1;
        }
    }

    // public void throwSarbacane()
    // {
    //     if (numberSarbacane > 0 && weaponNumber == 2)
    //     {
    //         Instantiate(playerManager.instance.sarbacaneShot, playerManager.instance.throwPoint.position, playerManager.instance.throwPoint.rotation);
    //         numberSarbacane -= 1;
    //     }
    // }

    public void throwPaperBoom()
    {
        if (numberPaperBoom > 0)
        {
           // Instantiate(playerMovment.instance.paperBoomShot, playerMovment.instance.throwPoint.position, playerMovment.instance.throwPoint.rotation);
            numberPaperBoom -= 1;
        }
    }

    public void throwBoulePuante()
    {
        if (numberBoulePuante > 0)
        {
            //Instantiate(playerMovment.instance.boulePuanteShot, playerMovment.instance.throwPoint.position, playerMovment.instance.throwPoint.rotation);
            numberBoulePuante -= 1;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (weaponNumber < 4)
            {

                weaponNumber += 1;


            }
        }


        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (weaponNumber > 1)
            {

                weaponNumber -= 1;

            }
        }


        if (Input.GetKeyUp(shoot))
        {


            throwWeapon();
            isShooting = true;
        }
        else
            isShooting = false;

    }
}
