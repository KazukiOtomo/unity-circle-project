using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveScriptEx2: MonoBehaviour
{
    [SerializeField] private Vector3 startPoint = new Vector3(0f, 2f, 0f);
    [SerializeField] private float deathHeight = -100;
    [SerializeField] private float playerSpeed = 15;
    [SerializeField] private float playerJumpPower = 14;
    [SerializeField] private float gravityPower = 16;

    [SerializeField] private AudioClip jump_SE;
    [SerializeField] private GroundCheckerScript groundChecker;

    private bool isGround;
    private bool jumping;
    private bool jumppadHit = false;

    private float Horizontal;
    private bool Jump;

    private float jumpInputTime;

    private Rigidbody rb;
    private AudioSource audio;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        rb.velocity = Vector3.zero;
    }

    private void Update()
    {
        if(transform.position.y <= deathHeight) { Death(); }
        isGround = groundChecker.IsGround();
        Horizontal = Input.GetAxis("Horizontal");
        Jump = Input.GetButton("Jump");
        Move(Horizontal, Jump);
        Gravity();

        Debug.Log(rb.velocity.y);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Jumppad") { rb.AddForce(transform.up * 10f, ForceMode.VelocityChange); }
        if (collision.gameObject.tag == "Dead")
        {
            Death();
        }

        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Result");
        }
    }

    private void Move(float move, bool jump)
    {
        if (isGround && jump && !jumping)
        {
            audio.PlayOneShot(jump_SE);
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
        if(rb.velocity.y <= -30f) { return; }
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
