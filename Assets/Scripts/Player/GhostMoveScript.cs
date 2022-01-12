using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostMoveScript : MonoBehaviour
{
    [SerializeField] private int player = 1;

    [SerializeField] private Vector3 startPoint = new Vector3(-25f, -10f, 0f);
    [SerializeField] private float playerSpeed = 12;
 
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

        transform.position = startPoint;
    }

    private void Update()
    {
        Move();
        
        float a = _ic.GetAccelMag();
        if (a > 2 && transform.localScale.sqrMagnitude < 8f)
        {
            transform.localScale *= 1.1f;
        }
        else if (1f < transform.localScale.sqrMagnitude)
        {
            transform.localScale *= 0.95f;
        }

    }

    private void Move()
    {
        float move = _ic.GetMove();
        float updown = _ic.GetHorizontal();

        if (Mathf.Abs(move) > Delta)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 90f*Mathf.Sign(move), 0));
        }
        
        rb.velocity = new Vector3(move * playerSpeed, updown*playerSpeed, 0f);
        
    }

}
