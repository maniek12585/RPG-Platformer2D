using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Character attributes:")]
    public float MOVEMENT_BASE_SPEED = 1.0f;

    [Space]
    [Header("Character statistics:")]
    public Vector2 movementDirection;

    public float movementSpeed = 5f;
    public float hidingValue = 1f;

    [Space]
    [Header("References")]
    public Rigidbody2D rb;

    [Space]
    [Header("Jumping values")]
    public float jumpVelocity = 5f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ProcessInputs();
        Move();
        Jump();
    }

    private void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            hidingValue = 0.5f;
        else hidingValue = 1f;

        rb.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED * hidingValue;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity = rb.velocity + Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity = rb.velocity + Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}