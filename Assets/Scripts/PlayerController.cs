using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jetpackForce = 75.0f;
    public float forwardMovementSpeed = 3.0f;
    private Rigidbody2D ridgidBody;

    public LayerMask groundLayer;
    public GameObject groundCheck;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        ridgidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(Input.GetButton("Fire1"))        
        {
            ridgidBody.AddForce(new Vector2(0,jetpackForce));
        }

        ridgidBody.velocity = new Vector2(forwardMovementSpeed, ridgidBody.velocity.y);

        UpdateGroundStatus();
    }

    void UpdateGroundStatus()
    {
        animator.SetBool("isGrounded", Physics2D.OverlapCircle(groundCheck.transform.position, 0.1f, groundLayer));
    }
}
