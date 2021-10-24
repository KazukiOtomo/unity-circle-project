using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShellMovement : MonoBehaviour
{
    private Vector3 shellMoving = new Vector3(0f, 0f, 0f);

    private float shellSpeed = -15f;
    // Start is called before the first frame update

    void Start()
    {
        Destroy(this.gameObject,5f);
    }
    // Update is called once per frame
    void Update()
    {
        shellMoving.x += shellSpeed * Time.deltaTime;
        this.transform.position = shellMoving;
    }
}
