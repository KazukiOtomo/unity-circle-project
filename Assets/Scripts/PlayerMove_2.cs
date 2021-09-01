using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove_2 : MonoBehaviour
{
	public float speed;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey("d"))
		{
			transform.position += transform.right * speed * Time.deltaTime;
		}
		if (Input.GetKey("a"))
		{
			transform.position -= transform.right * speed * Time.deltaTime;
		}
		if (Input.GetKey("w"))
		{
			transform.position += transform.up * speed * Time.deltaTime;
		}
		if (Input.GetKey("s"))
		{
			transform.position -= transform.up * speed * Time.deltaTime;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Finish")
		{
			SceneManager.LoadScene("Result");
		}
	}
}
