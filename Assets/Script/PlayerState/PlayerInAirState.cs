using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        player.Anim.SetFloat("ySpeed", player.CurrentVelocity.y);
        if(player.CheckInGround() && (player.CurrentVelocity.y <= 0)){
            if(player.CurrentVelocity.x != 0){
                player.stateMachine.ChangeState(player.MoveState);
            }else{
                player.stateMachine.ChangeState(player.IdleState);

            }
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
