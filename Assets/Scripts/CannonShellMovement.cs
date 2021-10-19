using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShellMovement : MonoBehaviour
{
    int n = 0;
    // Start is called before the first frame update

    void Start()
    {
        Destroy(this.gameObject,5f);
    }
    // Update is called once per frame
    void Update()
    {
        var shellMovement = new Vector3(-0.01f, 0f, 0f);
        transform.Translate(shellMovement);
    }
}
