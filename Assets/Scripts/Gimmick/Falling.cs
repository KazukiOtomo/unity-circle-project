using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public float FallSpeed = 0.5f;
    public float Range = 1.0f;
    public float DeleteTime = 3.0f;
    // public GameObject needler;

    // Start is called before the first frame update
    void Start()
    {
        // Player = GameObject.FindGameObjectWithTag("Player");

        // Update is called once per frame
    }
    void Update()
    {

            if ((GameObject.FindGameObjectWithTag("Player").transform.position.x < this.transform.position.x -Range && GameObject.FindGameObjectWithTag("Player").transform.position.y<this.transform.position.y) ||
            (GameObject.FindGameObjectWithTag("Player").transform.position.x < this.transform.position.x +Range && GameObject.FindGameObjectWithTag("Player").transform.position.y < this.transform.position.y))
            {
                this.gameObject.transform.Translate(0,  -1*FallSpeed,0);
            Destroy(this.gameObject, DeleteTime);
            }
        
    }
    /*void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            //Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
       // Destroy(this.gameObject,DeleteTime);
    }*/
}
