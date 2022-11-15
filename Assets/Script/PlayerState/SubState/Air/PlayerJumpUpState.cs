using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpUpState : PlayerAirState
{

    public PlayerJumpUpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }


    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocityY(playerData.jumpVelocity);
    }
    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(player.CurrentVelocity.y == 0.0f || IsJump == false){
            stateMachine.ChangeState(player.JumpStayState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        if(IsJump == true){
            player.SetVelocityY(playerData.jumpVelocity);
            // player.SetVelocityY(playerData.jumpUpModify * player.CurrentVelocity.y);
        }
    }
}
