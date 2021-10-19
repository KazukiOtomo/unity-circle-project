using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
	public float speed;
	
	public AudioClip jump_SE;

	AudioSource audio;
	void Start()
	{
		audio = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey("right"))
		{
			transform.position += transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey("left"))
		{
			transform.position -= transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey("up"))
		{
			transform.position += transform.up * speed * Time.deltaTime;
			
			if (Input.GetKeyDown("up"))
			{
				audio.PlayOneShot(jump_SE);
			}
		}
		if (Input.GetKey("down"))
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
		if (collision.gameObject.tag == "Dead")
		{
			transform.position = new Vector3(-20, 3, 0);
		}
	}
}