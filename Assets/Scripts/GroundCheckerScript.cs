using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckerScript : MonoBehaviour
{
    private string ground = "Ground";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == ground)
        {
            isGroundEnter = true;
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
    }
}
