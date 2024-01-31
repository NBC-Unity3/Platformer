using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public int speed;
    [SerializeField] public float jump;

    public float limitVelocityY = -2;
    public InputController playerMove;
    protected Rigidbody2D rigidbody;

    public bool JumpOn;
    public bool Secondjump;

    private Vector2 movementDirection = Vector3.zero;
    SpriteRenderer sprite;
    protected AnimationContoller animation;

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
        animation = GetComponent<AnimationContoller>();
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
            SoundManager.Instance.PlaySFX("Jump");
            JumpOn = false;
            Secondjump = true;
            rigidbody.AddForce(direction * jump, ForceMode2D.Impulse);

            animation.FirstJump();
        }
        else if (Secondjump)
        {
            SoundManager.Instance.PlaySFX("Jump");
            Secondjump = false;
            var velocity = rigidbody.velocity;
            velocity.y = 0;
            rigidbody.velocity = velocity;
            rigidbody.AddForce(direction * (jump - 2), ForceMode2D.Impulse);

            animation.SecondJump(rigidbody);
        }
    }



    private void ApplyMovment(Vector2 direction)
    {
        var velocity = rigidbody.velocity;

        if (velocity.y < limitVelocityY)
        {
            velocity.y = limitVelocityY;
        }


        if (direction.x == 0)
        {
            velocity.x = 0;
            rigidbody.velocity = velocity;
            return;
        }
        else if( direction.x != 0 && JumpOn)
        {
            // SoundManager.Instance.PlaySFX("Walk");
        }


        velocity.x = direction.x * speed; 
        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;


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
