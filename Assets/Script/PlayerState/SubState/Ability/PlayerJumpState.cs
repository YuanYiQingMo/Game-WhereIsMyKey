using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    private float YVelocity;

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        YVelocity = playerData.jumpVelocity;
        player.SetVelocityY(playerData.jumpVelocity);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(!player.InputHandler.IsJumping){
            player.stateMachine.ChangeState(player.InAirState);
        }else if(player.InputHandler.IsJumping && player.CurrentVelocity.y >= 0){
            YVelocity *= playerData.jumpUpModify;
            player.SetVelocityY(YVelocity);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}