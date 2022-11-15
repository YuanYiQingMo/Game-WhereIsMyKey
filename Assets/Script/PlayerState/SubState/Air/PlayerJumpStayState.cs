using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpStayState : PlayerAirState
{

    public PlayerJumpStayState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocityX(0.01f);
    }
    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (player.CurrentVelocity.y <= 0.0f)
        {
            stateMachine.ChangeState(player.JumpDownState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
