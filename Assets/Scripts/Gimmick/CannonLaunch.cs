using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLaunch : MonoBehaviour
{
    public GameObject shell;
    private Vector3 p = new Vector3();

    private void Start()
    {
        InvokeRepeating("Factory", 0f, 1.5f);
    }

    private void Factory()
    {
        p = gameObject.transform.position;

        GameObject g = Instantiate(shell);
        g.transform.position = p + new Vector3(-1f, 0f, 0f);
    }
}
