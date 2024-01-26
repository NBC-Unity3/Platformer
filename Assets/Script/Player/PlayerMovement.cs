using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] protected int speed;
    [SerializeField] protected float jump;

    public float limitVelocityY = -2; 
    protected InputController playerMove;
    protected Rigidbody2D rigidbody;

    protected bool JumpOn;
    protected bool Secondjump;

    private Vector2 movementDirection = Vector3.zero;
    SpriteRenderer sprite;

    private void Awake()
    {
        playerMove = GetComponent<InputController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        playerMove.OnMoveEvent += Move;
        playerMove.OnJumpEvent += Jump;
        JumpOn = false;
        Secondjump = false;
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
        if (JumpOn) 
        {
            JumpOn = false;
            Secondjump = true;
            rigidbody.AddForce(direction * jump, ForceMode2D.Impulse);
        }
        else if(Secondjump)
        {
            Secondjump = false;
            var velocity = rigidbody.velocity;
            velocity.y = 0;
            rigidbody.velocity = velocity;
            rigidbody.AddForce(direction * (jump-3), ForceMode2D.Impulse);
        }
    }



    private void ApplyMovment(Vector2 direction)
    {
        var velocity = rigidbody.velocity;
        
        if(velocity.y < limitVelocityY)
        {
            velocity.y = limitVelocityY;
        }



        if (direction.x == 0)
        {
            velocity.x = 0;
            rigidbody.velocity = velocity;
            return;
        }


        velocity.x = direction.x * 10; // x 속도 적용
        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;

        //스프라이트 반전
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
