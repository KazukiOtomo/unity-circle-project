using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityCheck : MonoBehaviour
{
    private float v;
    void Start()
    {
        v = GameObject.Find("PlayerEx").GetComponent<Rigidbody>().velocity.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
