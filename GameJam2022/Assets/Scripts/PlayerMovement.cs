using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Control Variables")]
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody rb;
    private Vector3 direction;    

    [Header("Ground Check")]
    public float hangtime = 0.1f;
    public float hangtimeCounter;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Animator animator;

    [Header("Sliders")]
    public float mSliderValue;
    public float jSliderValue;
    public float gSliderValue;
    public float hSliderValue;
  /*  public float ADSliderValue;
    public float DDSliderValue; */

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
        {
            hangtimeCounter = (hangtime * hSliderValue);
        }
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
        direction.x = input * (moveSpeed*mSliderValue);

        rb.velocity = new Vector3(direction.x, rb.velocity.y, rb.velocity.z);

    }
    public void Jump()
    {
        hangtimeCounter = 0f;
        rb.AddForce(Vector3.up * (jumpForce *jSliderValue), ForceMode.Impulse);

    }
}
