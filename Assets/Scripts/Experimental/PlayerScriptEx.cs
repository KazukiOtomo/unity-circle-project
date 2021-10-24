using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScriptEx : MonoBehaviour
{
	private CharacterController controller;

	public Vector3 startPoint = new Vector3(-60, 2, 0);//初期スタート地点用座標
	public float deathHeight = -30f;

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

		Death();
    }

	private void Update()
	{
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

		masterdir = transform.TransformDirection(movedir) * Time.deltaTime;
		controller.Move(masterdir);

		if (controller.isGrounded)
		{
			movedir.y = 0f;
			jumping = false;
		}

		if (this.gameObject.transform.position.y <= -30f)
		{
			Death();
		}
	}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Dead")
        {
			Death();
			//this.gameObject.transform.position = startPoint;
		}

		if(hit.gameObject.tag == "Finish")
        {
			SceneManager.LoadScene("Result");
        }
    }

	private void Death()
	{
		this.gameObject.transform.position = startPoint;
	}
}