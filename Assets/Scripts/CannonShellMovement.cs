using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShellMovement : MonoBehaviour
{

    // Start is called before the first frame update

    void Start()
    {
        Destroy(this.gameObject,5f);
    }
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += new Vector3(-15f, 0f, 0f) * Time.deltaTime;
    }
}
