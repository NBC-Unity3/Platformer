using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected int speed;
    [SerializeField] protected float jump;

    protected InputController playerMove;
    [HideInInspector] protected Rigidbody2D rigidbody;

    [HideInInspector] protected bool bJump;
    [HideInInspector] protected bool bMove;

    private Vector2 movementDirection = Vector3.zero;

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
        bMove = false;
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
        velocity.x = direction.x * 10; // x 加档 利侩
        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;
        //if (bMove)
        //{
        //    var velocity = rigidbody.velocity;
        //    velocity.x = direction.x * 10; // x 加档 利侩
        //    velocity.y = rigidbody.velocity.y;
        //    rigidbody.velocity = velocity;
        //}
    }

}
