using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloorHScript : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float diff = 3.0f;
    [SerializeField] private bool startDir = true;

    [SerializeField]private Vector3 basePosition;

    [SerializeField]private Vector3 targetP, targetN;

    private Vector3 moveVector = new Vector3(0,0,0);

    private void Start()
    {
        basePosition = this.gameObject.transform.position;

        targetP = basePosition + new Vector3(diff, 0f, 0f); 
        targetN = basePosition - new Vector3(diff, 0f, 0f);
    }

    private void Update()
    {
        //float step = speed * Time.deltaTime;
        if (startDir)
        {
            if (Vector3.Distance(transform.position, targetP) > 0.1f)
            {
                //moveVector = Vector3.MoveTowards(transform.position, targetP, step);
                moveVector = new Vector3(speed,0,0);
            }
            else
            {
                startDir = false;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, targetN) > 0.1f)
            {
                //moveVector = Vector3.MoveTowards(transform.position, targetN, step);
                moveVector = new Vector3(-1*speed,0,0);
            }
            else
            {
                startDir = true;
            }
        }

        transform.position += moveVector*Time.deltaTime;
    }

    public Vector3 MoveVector
    {
        get => moveVector;
        set => moveVector = value;
    }
}
