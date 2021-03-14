using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCR : MonoBehaviour
{
    public bool isJumping = false;

    public Animator animator;
    public bool isGrounded;
    private float x;
    private float y = 0.0f;
    private float jumpForce;
    [SerializeField] private float jumpStrength = 2f;
    private Rigidbody rb;
    private bool jumpPressed;
    private KeyCode jumpKey = KeyCode.Space;

    [SerializeField] private AudioSource jump;
    [SerializeField] private AudioSource land;
    private void Start()
    {
        x = jumpStrength;
        rb = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        jumpPressed = Input.GetKey(jumpKey);
        if(!jumpPressed && isGrounded)
        {
            isJumping = false;
            y = 0f;
        }

        if (jumpPressed && isGrounded && !isJumping)
        {
            isJumping = true;
            animator.SetBool("Jumping", true);
            y = 0f;
        }
        if(isJumping)
        {
            y += Time.deltaTime;
            if(y%1 == 0)
            {
                x = 0;
                for(int i = 0; i <= y; i++)
                {
                    x *= jumpStrength;
                }
            }
            jumpForce = x / y;
            rb.AddForce((jumpForce) * Vector3.up);
        }

            rb.AddForce(-9.81f * Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Ground"))
        {
            isGrounded = true;
            animator.SetBool("Jumping", false);
            land.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Ground"))
        {
            isGrounded = false;
            jump.Play();
        }
    }
}
