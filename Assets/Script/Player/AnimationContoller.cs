using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationContoller : MonoBehaviour
{
    private Animator animator;
    private PlayerColntroller controller;

    private static readonly int IsRun = Animator.StringToHash("IsRun");
    private static readonly int Jump1 = Animator.StringToHash("Jump1");
    private static readonly int Jump2 = Animator.StringToHash("Jump2");

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<PlayerColntroller>();
    }
    void Start()
    {
        controller.playerMove.OnMoveEvent += Move;
        controller.playerMove.OnJumpEvent += Jump;
    }

    void Move(Vector2 obj)
    {
        animator.SetBool(IsRun, obj.magnitude > .5f);
    }

    void Jump(Vector3 obj)
    {
        animator.SetBool(Jump1, controller.JumpOn);

        animator.SetBool(Jump2, controller.Secondjump);
    }
}
