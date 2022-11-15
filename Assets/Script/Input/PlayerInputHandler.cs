using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    //Move
    public Vector2 RawMovementInput { get; private set; }
    public int NormalInputX { get; private set; }
    public int NormalInputY { get; private set; }
    //Jump
    public bool IsJump { get; private set; }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormalInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        NormalInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsJump = true;
        }
    }
    public void HasJump(){
        IsJump = false;
    }
}
