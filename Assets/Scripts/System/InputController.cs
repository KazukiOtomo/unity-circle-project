using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private int playerNumber;
    private float[] move = new float[2];
    private float[] jump = new float[2];
    
    static InputController _inputController;

    public static InputController instance
    {
        get { return _inputController; }
        set { _inputController = value; }
    }


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerNumber=GetComponent<GameManagerScript>().GETPlayerNumber();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GETMove(int i)
    {
        return Input.GetAxis("Horizontal " + i);
    }

    public bool GETJump(int i)
    {
        return Input.GetButton("Jump " + i);
    }
}
