using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Control Variables")]
    public float moveSpeed;
    public float jumpHeight;
    public float gravity;

    private CharacterController controller;
    private Vector3 direction;

    [Header("Ground Check")]
    public float hangtime = 0.1f;
    private float hangtimeCounter;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private void Start()
    {
        // get components
        controller = GetComponent<CharacterController>();

        // set default values
    }
    private void Update()
    {
        MovePlayer();

        // ground check
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded)
        {
            hangtimeCounter = hangtime;
            direction.y -= 1 * Time.deltaTime;
        }
        else
        {
            hangtimeCounter -= Time.deltaTime;
            // apply gravity
            direction.y += gravity * Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && hangtimeCounter > 0f)
            Jump();

    }
    public void MovePlayer()
    {
        float input = Input.GetAxis("Horizontal");
        direction.x = input * moveSpeed;

        controller.Move(direction * Time.deltaTime);
    }
    public void Jump()
    {
        hangtimeCounter = 0f;
        direction.y = jumpHeight;
    }
}
