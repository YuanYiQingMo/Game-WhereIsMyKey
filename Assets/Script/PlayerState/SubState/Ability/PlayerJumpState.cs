using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        player.InputHandler.HasJump();
        player.SetVelocityY(playerData.jumpVelocity);
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(player.CurrentVelocity.y < 0.01f){
            stateMachine.ChangeState(player.LandState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}