using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Control Variables")]
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody rb;
    private Vector3 direction;    

    [Header("Ground Check")]
    public float hangtime = 0.1f;
    private float hangtimeCounter;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Animator animator;

    private void Start()
    {
        // get components
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        // set default values
    }
    private void Update()
    {
        MovePlayer();
        MyInput();

        // ground check
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        if (isGrounded)
            hangtimeCounter = hangtime;
        else
            hangtimeCounter -= Time.deltaTime;
    }
    public void MyInput()
    {
        if (Input.GetButtonDown("Jump") && hangtimeCounter > 0f)
            Jump();
    }
    public void MovePlayer()
    {
        float input = Input.GetAxis("Horizontal");
        direction.x = input * moveSpeed;

        rb.velocity = new Vector3(direction.x, rb.velocity.y, rb.velocity.z);
    }
    public void Jump()
    {
        hangtimeCounter = 0f;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
