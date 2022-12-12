using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator cAnimator;
    public GameObject player;
    public bool check;
    // Start is called before the first frame update
    void Awake()
    {
        cAnimator = GetComponent<Animator>();
        cAnimator.SetBool("test", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            cAnimator.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            cAnimator.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            cAnimator.SetBool("Walk", false);
            cAnimator.SetBool("Test", true);
        }
        if (player.GetComponent<PlayerMovement>().hangtimeCounter < 0f)
        {
            cAnimator.SetBool("Jump", true);
            check = true;
        }
        if (player.GetComponent<PlayerMovement>().hangtimeCounter > 0f && (check = true))
        {
            cAnimator.SetBool("Jump", false);
            check = false;
        }

    }
}
