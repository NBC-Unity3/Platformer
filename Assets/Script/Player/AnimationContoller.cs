using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationContoller : MonoBehaviour
{
    private Animator animator;
    private PlayerColntroller controller;

    private static readonly int IsRun = Animator.StringToHash("IsRun");
    private static readonly int Jump1 = Animator.StringToHash("IsJump1");
    private static readonly int Jump2 = Animator.StringToHash("IsJump2");
    private static readonly int Jump3 = Animator.StringToHash("IsJump3");

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<PlayerColntroller>();
    }
    void Start()
    {
        controller.playerMove.OnMoveEvent += Move;
    }

    void Move(Vector2 obj)
    {
        animator.SetBool(IsRun, obj.magnitude > .5f);
    }

    public void FirstJump()
    {
        animator.SetBool(Jump1, true);
    }

    public void SecondJump(Rigidbody2D rigidbody)
    {
        var velocity = rigidbody.velocity;
        if (velocity.x < 0)
        {
            animator.SetBool(Jump3, true);
        }
        else if(velocity.x >0)
        {
            animator.SetBool(Jump2, true);
        }
    }

    public void ClearJump()
    {
        animator.SetBool(Jump1, false);
        animator.SetBool(Jump2, false);
        animator.SetBool(Jump3, false);
    }
}
