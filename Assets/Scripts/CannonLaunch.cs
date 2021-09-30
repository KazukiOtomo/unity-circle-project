using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLaunch : MonoBehaviour
{
    public GameObject shell;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Factory",0f,1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Factory()
    {
        GameObject g = Instantiate(shell);
        g.transform.position = this.gameObject.transform.position + new Vector3(-1.4f, 0.9f, 0f);
    }
}
