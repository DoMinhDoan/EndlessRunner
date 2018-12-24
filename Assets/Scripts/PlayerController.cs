using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jetpackForce = 75.0f;
    public float forwardMovementSpeed = 3.0f;
    private Rigidbody2D ridgidBody;

    // Start is called before the first frame update
    void Start()
    {
        ridgidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(Input.GetButton("Fire1"))        
        {
            ridgidBody.AddForce(new Vector2(0,jetpackForce));
        }

        ridgidBody.velocity = new Vector2(forwardMovementSpeed, ridgidBody.velocity.y);
    }
}
