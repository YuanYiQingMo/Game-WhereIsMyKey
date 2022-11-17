using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    protected int Xinput;

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

        CheckIfShouldJump();
        Xinput = player.InputHandler.NormalInputX;
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    private void CheckIfShouldJump()
    {
        if (player.InputHandler.IsJump && player.CheckCanJump())
        {
            stateMachine.ChangeState(player.JumpState);
        }
    }
}
