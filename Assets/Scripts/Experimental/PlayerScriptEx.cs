using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScriptEx : MonoBehaviour
{
	private CharacterController controller;

	public Vector3 movedir = Vector3.zero;
	public Vector3 masterdir = Vector3.zero;
	public float jumpSpeed = 25f;
	public float moveSpeed = 15f;
	public float gravity = 50f;

	private bool jumping = true;
	private float jumpInputingTime;

    private void Start()
    {
		controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
		Debug.Log(Time.deltaTime);
		//ジャンプ
		if (Input.GetKeyDown("up") && controller.isGrounded)
		{
			jumping = true;
			jumpInputingTime = 0;
		}
		if (jumping)
		{
			if (Input.GetKey("up") && (jumpInputingTime <= 0.25f))
			{
				movedir.y = jumpSpeed * 0.65f;
				jumpInputingTime += Time.deltaTime;
			}
			else
			{
				jumping = false;
			}
		}

		//横移動
		movedir.z = moveSpeed * Input.GetAxis("Horizontal");
			//Transformコンポーネントよりy軸に90度回転しているため、z方向にベクトルを設定している。
				//プレイヤーの向きを移動方向へ合わせるシステムをつくる場合は、PlayerScriptExにて使用する関数を再検討するが必要あるかも。

        //重力
        movedir.y -= gravity * Time.deltaTime;

        masterdir = transform.TransformDirection(movedir)*Time.deltaTime;
		controller.Move(masterdir);

		if (controller.isGrounded)
		{
			movedir.y = 0f;
			jumping = false;
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
			transform.position = new Vector3(-20, 3, -18);
		}
    }


    /*
	public float speed;
	public AudioClip jump_SE;
	AudioSource audio;
	public bool onGround;
	private Rigidbody rb = null;

	

	void Start()
	{
		audio = GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		//横移動
		if (Input.GetKey("right"))
		{
			transform.position += transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey("left"))
		{
			transform.position -= transform.forward * speed * Time.deltaTime;
		}

		//ジャンプ
        if (Input.GetKeyDown("up"))
        {
			inputJumpButton = true;
        }
        if (Input.GetKeyUp("up"))
        {
			inputJumpButton = false;
		}

        if (onGround == true)
        {
			Debug.Log("接地");
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
			transform.position = new Vector3(-20, 3, -18);
		}
	}

    private void OnCollisionStay(Collision collision)
    {
		if (collision.gameObject.tag == "Ground")
		{
			onGround = true;
		}
	}

    private void OnCollisionExit(Collision collision)
    {
		if (collision.gameObject.tag == "Ground")
		{
			onGround = false;
		}
	}
	*/
}