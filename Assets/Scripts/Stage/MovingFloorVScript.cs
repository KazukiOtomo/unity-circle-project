using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloorVScript : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float diff = 3.0f;
    [SerializeField] private bool startDir = true;
    [SerializeField] private float intercept=0f;

    //private Rigidbody rb;

    private Vector3 basePosition;

    private Vector3 targetP, targetN;

    private void Start()
    {
        basePosition = this.gameObject.transform.position;
        //rb = this.gameObject.GetComponent<Rigidbody>();

        targetP = basePosition + new Vector3(0f, diff, 0f); 
        targetN = basePosition - new Vector3(0f, diff, 0f);

        transform.position += new Vector3(0f, intercept * diff, 0f);
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        if (startDir)
        {
            if (Vector3.Distance(transform.position, targetP) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetP, step);
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
                transform.position = Vector3.MoveTowards(transform.position, targetN, step);
            }
            else
            {
                startDir = true;
            }
        }
    }
}
