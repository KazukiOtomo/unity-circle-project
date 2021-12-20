using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FeetCheckerScript : MonoBehaviour
{
    [SerializeField] private bool isGround = false;
    [SerializeField] private bool isJumppad = false;
    [SerializeField] private bool isHorizontalMovingFloor = false;

    private MovingFloorHScript _floor;

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

    public bool IsHorizontalMovingFloor
    {
        get => isHorizontalMovingFloor;
        set => isHorizontalMovingFloor = value;
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

        if (collision.gameObject.CompareTag("HorizontalMovingFloor"))
        {
            isHorizontalMovingFloor = true;
            _floor = collision.gameObject.GetComponent<MovingFloorHScript>();
            isGround = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
        if (collision.gameObject.CompareTag("HorizontalMovingFloor"))
        {
            isHorizontalMovingFloor = false;
            isGround = false;
        }
    }

    public Vector3 MovingFloor()
    {
        return _floor.MoveVector;
    }
}
