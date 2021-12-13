using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    private int playerNumber = 2;
    private GameObject[] teamRed;
    private GameObject[] teamBlue;

    private void Start()
    {
        /*
        foreach(GameObject i in teamRed)
        {

        }
        */
    }

    private void Update()
    {

    }

    public int GETPlayerNumber()
    {
        return playerNumber;
    }
}
