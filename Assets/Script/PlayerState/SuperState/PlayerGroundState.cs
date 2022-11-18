using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    protected int Xinput;

    protected bool IsDashing { get; private set; }

    public PlayerGroundState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Xinput = player.InputHandler.NormalInputX;
        IsDashing = player.InputHandler.IsDashing;
        if (!player.CheckInGround())
        {
            stateMachine.ChangeState(player.InAirState);
        }
        else
        {
            CheckIfShouldJump();
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    private void CheckIfShouldJump()
    {
        if (player.InputHandler.IsJumping && player.CheckInGround())
        {
            stateMachine.ChangeState(player.JumpState);
        }
    }
}
