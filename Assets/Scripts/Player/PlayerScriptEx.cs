using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScriptEx : MonoBehaviour
{
	private CharacterController controller;

	[SerializeField] private Vector3 startPoint = new Vector3(-60, 2, 0);//初期スタート地点用座標
	[SerializeField] private float deathHeight = -30f;

	[SerializeField] private Vector3 movedir = Vector3.zero;
	[SerializeField] private float jumpSpeed = 25f;
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float gravity = 50f;

	public AudioClip jump_SE;
	private AudioSource audio;

	private bool jumping = true;
	private bool jumppadHit = false;
	private float jumpInputingTime;

    private void Start()
    {
		controller = GetComponent<CharacterController>();
		audio = GetComponent<AudioSource>();
		Death();
    }

	private void Update()
	{
		//ジャンプ
		if (Input.GetKeyDown("up") && controller.isGrounded)
		{
			audio.PlayOneShot(jump_SE);
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

		//masterdir = transform.TransformDirection(movedir) * Time.deltaTime;
		controller.Move(transform.TransformDirection(movedir) * Time.deltaTime);

		if (controller.isGrounded)
		{
			movedir.y = 0f;
			jumping = false;
		}

		if (jumppadHit)
        {
			movedir.y = 30f;
			jumppadHit = false;
        }

		if (this.gameObject.transform.position.y <= deathHeight)
		{
			Debug.Log("Fall");
			Death();
		}
	}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Dead")
        {
			Debug.Log(hit.gameObject.name);
			Death();
		}

		if (hit.gameObject.tag == "Finish")
        {
			SceneManager.LoadScene("Result");
        }

		if (hit.gameObject.tag == "Jumppad")
        {
			jumppadHit = true;
        }
    }

    private void Death()
	{
		this.gameObject.transform.position = startPoint;
	}
}