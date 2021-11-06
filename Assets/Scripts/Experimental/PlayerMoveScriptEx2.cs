using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveScriptEx2: MonoBehaviour
{
    [SerializeField] private Vector3 startPoint = new Vector3(0f, 2f, 0f);
    [SerializeField] private float deathHeight = -60;
    [SerializeField] private float playerSpeed = 15;
    [SerializeField] private float playerJumpPower = 14;
    [SerializeField] private float gravityPower = 16;

    [SerializeField] public AudioClip jumpSE;
    [SerializeField] public AudioClip jumppadSE;

    [SerializeField] private FeetCheckerScript feetChecker;

    private bool isGround;

    private bool isJumppad;
    private bool jumppadSEPlayed = false;

    private float Horizontal;
    private bool Jump;

    private bool jumping;
    private float jumpInputTime;

    private Rigidbody rb;
    private new AudioSource audio;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        rb.velocity = Vector3.zero;

        //プレイヤー位置の初期化
        Death();
    }

    private void Update()
    {
        isGround = feetChecker.IsGround();
        isJumppad = feetChecker.IsJumppad();

        //プレイヤー操作
        Horizontal = Input.GetAxis("Horizontal 1");
        Jump = Input.GetButton("Jump 1");
        Move(Horizontal, Jump);

        //落下死
        if (transform.position.y <= deathHeight) { Death(); }

        //トランポリン
        if (isJumppad == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, 30f, 0f);
            if(!jumppadSEPlayed)
            {
                audio.PlayOneShot(jumppadSE);
                jumppadSEPlayed = true;
            }
        }
        else
        {
            jumppadSEPlayed = false;
        }

        Gravity();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //トラップ
        if (collision.gameObject.tag == "Dead")
        {

            Death();
        }

        //ゴールの処理
        if (collision.gameObject.tag == "Finish")
        {

            SceneManager.LoadScene("Result");
        }
    }

    private void Move(float move, bool jump)
    {
        if (isGround && jump && !jumping)
        {
            audio.PlayOneShot(jumpSE);
            jumping = true;
            jumpInputTime = 0f;
        }

        if (jumping)
        {
            if (jump && (jumpInputTime <= 0.25f))
            {
                rb.velocity = new Vector3(rb.velocity.x, playerJumpPower, 0f);
                jumpInputTime += Time.deltaTime;
            }
            else
            {
                jumping = false;
            }
        }

        rb.velocity = new Vector3(move * playerSpeed, rb.velocity.y, 0f);
    }

    private void Gravity()
    {
        if(rb.velocity.y <= -30f)
        {
            rb.velocity = new Vector3(rb.velocity.x, -30f, 0f);
            return;
        }
        if (!isGround)
        {
            rb.AddForce(new Vector3(0f, -gravityPower, 0f));
        }
    }

    private void Death()
    {
        this.gameObject.transform.position = startPoint;
    }
}
