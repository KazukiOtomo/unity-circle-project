using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCheckerScript : MonoBehaviour
{
    [SerializeField] private bool isGround = false;
    private string ground = "Ground";
    private bool isGroundEnter, isGroundStay, isGroundExit;

    [SerializeField] private bool isJumppad = false;
    private string jumppad = "Jumppad";
    private bool isJumppadEnter, isJumppadStay, isJumppadExit;

    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }
        else
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;

        return isGround;
    }

    public bool IsJumppad()
    {
        if (isJumppadEnter)
        {
            isJumppad = true;
        }
        else if (isJumppadExit)
        {
            isJumppad = false;
        }

        isJumppadEnter = false;
        isJumppadStay = false;
        isJumppadExit = false;

        return isJumppad;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == ground)
        {
            isGroundEnter = true;
        }

        if(collision.tag == jumppad)
        {
            isJumppadEnter = true;
            Debug.Log("enter");
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == ground)
        {
            isGroundStay = true;
        }

        if (collision.tag == jumppad)
        {
            isJumppadStay = true;
            Debug.Log("stay");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == ground)
        {
            isGroundExit = true;
        }

        if(collision.tag == jumppad)
        {
            isJumppadExit = true;
            Debug.Log("exit");
        }
    }
}
