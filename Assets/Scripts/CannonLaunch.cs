﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLaunch : MonoBehaviour
{
    public GameObject shell;
    private Vector3 p = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Factory", 0f, 1.5f);
        p = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Factory()
    {
        GameObject g = Instantiate(shell);
        g.transform.position = p + new Vector3(-0.5f, 0f, 0f);
    }
}
