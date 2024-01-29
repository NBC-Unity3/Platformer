using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationContoller : MonoBehaviour
{
    private Animator animator;
    private PlayerColntroller controller;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<PlayerColntroller>();
    }
    void Start()
    {
        controller.playerMove.OnMoveEvent += Move;
        //controller.playerMove.OnJumpEvent += Jump;
    }

    void Move(Vector2 obj)
    {

    }

    void Jump(Vector3 obj)
    {

    }
}
