﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(SelectSceneLoad),5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectSceneLoad()
    {
        SceneManager.LoadScene("Select");
    }
}
