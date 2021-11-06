using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCheckerScript : MonoBehaviour
{
    private string ground = "Ground";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

    private string jumppad = "Jumppad";
    private bool isJumppad = false;
    private bool isJumppadEnter, isJumppadExit;

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
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == ground)
        {
            isGroundStay = true;
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
        }
    }
}
