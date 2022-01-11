using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    private List<Joycon> joycons;

    public float[] stick;
    public Vector3 gyro;
    public Vector3 accel;
    public int jc_ind = 0;
    public Quaternion orientation;
    
    private bool isLeft=false;
    [SerializeField]private int characternumber = 0;

    [SerializeField]private bool isAttacker = false;

    void Start()
    {
        gyro = new Vector3(0, 0, 0);
        accel = new Vector3(0, 0, 0);
        joycons = JoyconManager.Instance.j;
        if (joycons.Count < jc_ind+1){
            Destroy(gameObject);
        }
        characternumber = jc_ind;
    }

    // Update is called once per frame
    void Update()
    {
        if (joycons.Count > 0)
        {
            Joycon j = joycons [jc_ind];
            isLeft = j.isLeft;
            stick = j.GetStick();

        }
    }

    public float GetMove()
    {
        if (joycons.Count > 0)
        {
            Joycon j = joycons[jc_ind];
            isLeft = j.isLeft;
            stick = j.GetStick();
            return -1f*FixInputStick() * stick[1];
        }

        return 0f;
    }

    public bool GetJump()
    {
        if (joycons.Count > 0)
        {
            Joycon j = joycons[jc_ind];
            isLeft = j.isLeft;
            stick = j.GetStick();
           return j.GetButton(FixInputButton(Joycon.Button.DPAD_DOWN));
        }

        return false;
    }
    
    public float GetHorizontal()
    {
        if (joycons.Count > 0)
        {
            Joycon j = joycons[jc_ind];
            isLeft = j.isLeft;
            stick = j.GetStick();
            return FixInputStick() * stick[0];
        }

        return 0f;
    }
    
    private float FixInputStick()
    {
        return isLeft ? 1f : -1f;
    }

    private Joycon.Button FixInputButton(Joycon.Button b)
    {
        if (isLeft)
        {
            if (b == Joycon.Button.DPAD_DOWN) return Joycon.Button.DPAD_LEFT;
            if (b == Joycon.Button.DPAD_LEFT) return Joycon.Button.DPAD_UP;
            if (b == Joycon.Button.DPAD_UP) return Joycon.Button.DPAD_RIGHT;
            if (b == Joycon.Button.DPAD_RIGHT) return Joycon.Button.DPAD_DOWN;
        }
        else
        {
            if (b == Joycon.Button.DPAD_DOWN) return Joycon.Button.DPAD_RIGHT;
            if (b == Joycon.Button.DPAD_LEFT) return Joycon.Button.DPAD_DOWN;
            if (b == Joycon.Button.DPAD_UP) return Joycon.Button.DPAD_LEFT;
            if (b == Joycon.Button.DPAD_RIGHT) return Joycon.Button.DPAD_UP;
        }
        return b;
    }
}
