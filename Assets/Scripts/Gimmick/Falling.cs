using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public float FallSpeed = 0.1f;
    public float Range = 0.1f;
    public float DeleteTime = 3.0f;

    private bool flg = false;

    GameObject[] p;
    void Start()
    {
        p = GameObject.FindGameObjectsWithTag("Player");
    }
    void LateUpdate()
    {
        foreach(GameObject player in p){
            if (Mathf.Abs(player.transform.position.x - transform.position.x) < Range
                && player.transform.position.y < transform.position.y)
            {
                flg = true;
                Destroy(this.gameObject, DeleteTime);
            }
        }
        
        if(flg)this.gameObject.transform.Translate(0,  -0.1f*FallSpeed,0);
    }
}
