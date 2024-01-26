using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] protected int speed;
    [SerializeField] protected float jump;

    protected InputController playerMove;
    [HideInInspector] protected Rigidbody2D _rigidbody;

    [HideInInspector] protected bool bJump;

    private Vector2 movementDirection = Vector3.zero;
    SpriteRenderer sprite;

    private void Awake()
    {
        playerMove = GetComponent<InputController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        playerMove.OnMoveEvent += Move;
        playerMove.OnJumpEvent += Jump;
        bJump = false;
        sprite = GetComponentInChildren<SpriteRenderer>();
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
            _rigidbody.AddForce(direction * jump, ForceMode2D.Impulse);
        }
    }

    private void ApplyMovment(Vector2 direction)
    {
        var velocity = _rigidbody.velocity;
        if (direction.x == 0)
        {
            velocity.x = 0;
            _rigidbody.velocity = velocity;
            return;
        }


        velocity.x = direction.x * 10; // x �ӵ� ����
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;

        //��������Ʈ ����
        if (velocity.x < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }


}
