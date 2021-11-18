using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCheckerScript : MonoBehaviour
{
    [SerializeField] private bool isGround = false;
    [SerializeField] private bool isJumppad = false;

    public bool IsJumppad
    {
        get => isJumppad;
        set => isJumppad = value;
    }
    
    public bool IsGround
    {
        get => isGround;
        set => isGround = value;
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }

        if (collision.gameObject.CompareTag("Jumppad"))
        {
            isJumppad = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
