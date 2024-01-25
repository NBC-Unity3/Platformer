using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public float jump;

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
            bJump = false;
            rigidbody.AddForce(direction * jump, ForceMode2D.Impulse);
        }
    }

    private void ApplyMovment(Vector2 direction)
    {
        var velocity = rigidbody.velocity;
        velocity.x = direction.x * 10; // x 속도 적용

        // 유지되는 y 속도
        velocity.y = rigidbody.velocity.y;

        rigidbody.velocity = velocity;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (bJump) return;
        Invoke("JumpOn", 0.05f);
    }

    private void JumpOn()
    {
        bJump = true;
    }
}
