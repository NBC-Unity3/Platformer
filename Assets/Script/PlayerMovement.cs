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

    private Vector2 movementDirection = Vector3.zero;
    SpriteRenderer sprite;

    AudioManager audioManager;

    private void Awake()
    {
        playerMove = GetComponent<InputController>();
        rigidbody = GetComponent<Rigidbody2D>();
        
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
            audioManager.PlaySFX(audioManager.jumpClip);
            bJump = false;
            rigidbody.AddForce(direction * jump, ForceMode2D.Impulse);
        }
    }

    private void ApplyMovment(Vector2 direction)
    {
        var velocity = rigidbody.velocity;
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
