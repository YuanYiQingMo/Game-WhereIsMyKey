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
    public bool IsJumping { get; private set; }

    //Dash
    public bool IsDashing {get; private set;}

    //InputTimer
    public float InputTimerSet = 0.5f;
    private float InputTimer;
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormalInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        NormalInputY = (int)(RawMovementInput * Vector2.up).normalized.y;

    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        InputTimer = InputTimerSet;
        if (context.started)
        {
            IsJumping = true;
        }
        if (context.canceled)
        {
            IsJumping = false;
        }
    }

    public void OnDashInput(InputAction.CallbackContext context){
        if(context.started){
            IsDashing = true;
        }
        if(context.canceled){
            IsDashing = false;
        }
    }

    private void Update()
    {
        if (InputTimer >= 0)
        {
            InputTimer -= Time.deltaTime;
        }
        else
        {
            IsJumping = false;
        }
    }
}
