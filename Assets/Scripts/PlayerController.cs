using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jetpackForce = 75.0f;
    public float forwardMovementSpeed = 3.0f;   

    public LayerMask groundLayer;
    public GameObject groundCheck;

    private Animator _animator;
    private Rigidbody2D _ridgidBody;
    private ParticleSystem _particleSystem;
    private bool _isGrounded;
    private bool _jetpackActive;
    private float _jetpackRateOverTime;

    // Start is called before the first frame update
    void Start()
    {
        _ridgidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _isGrounded = false;

        var emission = _particleSystem.emission;
        _jetpackRateOverTime = emission.rateOverTime.constant;
    }

    private void FixedUpdate()
    {
        _jetpackActive = Input.GetButton("Fire1");
        if (_jetpackActive)
        {
            _ridgidBody.AddForce(new Vector2(0,jetpackForce));
        }

        _ridgidBody.velocity = new Vector2(forwardMovementSpeed, _ridgidBody.velocity.y);

        UpdateGroundStatus();
    }

    private void Update()
    {
        UpdateJetPack();
    }

    void UpdateGroundStatus()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, 0.1f, groundLayer);
        _animator.SetBool("isGrounded", _isGrounded);
    }

    void UpdateJetPack()
    {
        var psEmission = _particleSystem.emission;

        psEmission.enabled = !_isGrounded;
        if(_jetpackActive)
        {
            psEmission.rateOverTime = _jetpackRateOverTime;
        }
        else
        {
            psEmission.rateOverTime = _jetpackRateOverTime / 4;
        }
    }
}
