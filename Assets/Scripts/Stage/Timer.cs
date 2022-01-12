using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]private Text text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Time Remaining: " + Mathf.Floor(GameManagerScript.t*10)/10f +"s";
    }
}
