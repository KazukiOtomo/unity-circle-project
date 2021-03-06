using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField] private int player = 1;

    [SerializeField] private Vector3 startPoint = new Vector3(-25f, 34f, 0f);
    [SerializeField] private float deathHeight = -40;
    [SerializeField] private float playerSpeed = 15;
    [SerializeField] private float playerJumpPower = 14;
    [SerializeField] private float gravityPower = 16;

    public AudioClip jumpSE;
    public AudioClip jumppadSE;
    public AudioClip damaged;

    [SerializeField] private FeetCheckerScript feetChecker;

    [SerializeField] private bool isGround;
    [SerializeField] private bool isJumppad = false;
    [SerializeField] private bool isHorizontalMovingFloor = false;
 
    private Rigidbody rb;
    private new AudioSource audio;

    private Animator animator;
    
    private const float Delta =0.1f;

    [SerializeField]private InputController _ic;

        private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        rb.velocity = Vector3.zero;
        animator = gameObject.GetComponent<Animator>();

        ResetPosition();
    }

    private void Update()
    {
        isGround = feetChecker.IsGround;
        isJumppad = feetChecker.IsJumppad;
        isHorizontalMovingFloor = feetChecker.IsHorizontalMovingFloor;

        //プレイヤー操作
        Move();

        //落下死
        if (transform.position.y <= deathHeight)
        {
            Death();
        }

        //トランポリン
        if (isJumppad)
        {
            rb.velocity = new Vector3(rb.velocity.x, 30f, 0f);
            audio.PlayOneShot(jumppadSE);
            feetChecker.IsJumppad = false;
        }

        animator.SetBool("Mooving", !(Mathf.Abs(rb.velocity.x) <= 0.1f));

        Gravity();
    }

    private void Move()
    {
        float move = _ic.GetMove();
        bool jump = _ic.GetJump();

        if (Mathf.Abs(move) > Delta)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 90f*Mathf.Sign(move), 0));
        }

        if (isGround && jump)
        {
            audio.PlayOneShot(jumpSE);
            StartCoroutine(JumpingMove());
            feetChecker.IsGround = false;
        }
        rb.velocity = new Vector3(move * playerSpeed, rb.velocity.y, 0f);

        if (isHorizontalMovingFloor)
        {
            rb.velocity += feetChecker.MovingFloor();
        }
    }

    IEnumerator JumpingMove()
    {
        float jumpTime = 0f;
        while (jumpTime <= 0.25f)
        {
            bool jump = _ic.GetJump();
            if (jump) rb.velocity = new Vector3(rb.velocity.x, playerJumpPower, 0f);
            jumpTime += Time.deltaTime;
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //トラップ
        if (collision.gameObject.CompareTag("Dead"))
        {
            Death();
        }
        
        if (collision.gameObject.CompareTag("Ghost"))
        {
            Death();
        }

        //ゴールの処理
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Result");
        }
    }

    private void Gravity()
    {
        if (rb.velocity.y <= -30f)
        {
            rb.velocity = new Vector3(rb.velocity.x, -30f, 0f);
            return;
        }
        rb.AddForce(new Vector3(0f, -gravityPower * Time.deltaTime * 60f, 0f));
    }

    private void Death()
    {
        //show something action like "GAME OVER"
        audio.PlayOneShot(damaged);
        ResetPosition();
    }

    private void ResetPosition()
    {
        gameObject.transform.position = startPoint;
    }
}
