using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManagementScript : MonoBehaviour
{
    private RectTransform i;
    private Transform o;

    private void Start()
    {
        //i = GameObject.Find("Image2").GetComponent<RectTransform>();
        o = GameObject.Find("Cannon").GetComponent<Transform>();
    }

    private void Update()
    {
        var up = Input.GetKeyDown("up");
        var down = Input.GetKeyDown("down");
        var right = Input.GetKeyDown("right");
        var left = Input.GetKeyDown("left");

        if (up)
        {
            o.position += new Vector3(0f, 1f, 0f);
        }
        if (down)
        {
            o.position += new Vector3(0f, -1f, 0f);
        }
        if (right)
        {
            o.position += new Vector3(1f, 0f, 0f);
        }
        if (left)
        {
            o.position += new Vector3(-1f, 0f, 0f);
        }
    }
}
