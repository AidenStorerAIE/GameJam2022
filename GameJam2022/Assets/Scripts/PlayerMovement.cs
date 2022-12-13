using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Control Variables")]
    public float moveSpeed;
    public float jumpForce;
    public int stompDamage = 1;
    private Rigidbody rb;
    private Vector3 direction;    

    [Header("Ground Check")]
    public float hangtime = 0.1f;
    public float hangtimeCounter;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool isGrounded;

    private Animator animator;

    [Header("Sliders")]
    public float mSliderValue;
    public float jSliderValue;
    public float gSliderValue;
    public float hSliderValue;
    public float stompSliderValue;
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
            hangtimeCounter = (hangtime * hSliderValue);
        else
        {
            CheckStomp();
            hangtimeCounter -= Time.deltaTime;
        }
    }
    void CheckStomp()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, 0.5f, LayerMask.GetMask("Enemy"));
        foreach (Collider nearbyObject in targets)
        {
            if (nearbyObject.GetComponent<Health>())
            {
                nearbyObject.GetComponent<Health>().TakeDamage(stompDamage * stompSliderValue);
                Jump(3);
            }
        }
    }    
    public void MyInput()
    {
        if (Input.GetButtonDown("Jump") && hangtimeCounter > 0f)
            Jump(jumpForce * jSliderValue);
    }
    public void MovePlayer()
    {
        float input = Input.GetAxis("Horizontal");
        direction.x = input * (moveSpeed*mSliderValue);

        rb.velocity = new Vector3(direction.x, rb.velocity.y, rb.velocity.z);
    }
    public void Jump(float force)
    {
        Debug.Log("Jump");
        hangtimeCounter = 0f;
        rb.AddForce(Vector3.up * (force), ForceMode.Impulse);
    }
}
