using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector3> OnJumpEvent; 

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallJumpEvent(Vector3 direction)
    {
        OnJumpEvent?.Invoke(direction);
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnJump(InputValue value)
    {

        Vector3 jumpInput = Vector3.up;
        CallJumpEvent(jumpInput);
    }

    public void OnConsumeItem() 
    {
        Debug.Log("ConsumeItemKey Pressed!");
        GetComponent<PlayerColntroller>()?.CallOnConsumeItem();
    }

}
