using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 5;
    public float jump = 5;

    InputController playerMove;
    private Rigidbody2D rigidbody;

    private Vector2 movementDirection = Vector3.zero;
    bool bJump;

    private void Awake()
    {
        playerMove = GetComponent<InputController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        playerMove.OnMoveEvent += Move;
        playerMove.OnJumpEvent += Jump;
        bJump = false;
    }

    void FixedUpdate()
    {
        ApplyMovment(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void Jump(Vector3 direction)
    {
        if(bJump)
        {
            direction = direction * jump;
            rigidbody.AddForce(direction);
            bJump = false;
            rigidbody.gravityScale = 20.0f;
        }
    }

    private void ApplyMovment(Vector2 direction)
    {
        direction.x = direction.x * 10; 

        rigidbody.velocity = direction;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        bJump = true;
        rigidbody.gravityScale = 1.0f;
    }
}
