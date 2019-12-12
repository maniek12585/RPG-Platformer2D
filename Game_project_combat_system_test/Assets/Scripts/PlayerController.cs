using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float _speed;
    public float _jumpForce;
    private float _moveInput;

    private bool _isGrounded;
    public Transform _feetCollider;
    public float _checkRadius;
    public LayerMask _ground;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_moveInput * _speed, _rb.velocity.y);
    }

    void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_feetCollider.position, _checkRadius, _ground);

        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
            _rb.velocity = Vector2.up * _jumpForce;
    }
}
