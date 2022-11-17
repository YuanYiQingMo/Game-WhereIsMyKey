using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        player.CheckIfShouldFlip(Xinput);
        Move();
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    private void Move(){
        player.SetVelocityX(playerData.movementVelocity * Xinput);
        if(Xinput == 0){
            stateMachine.ChangeState(player.IdleState);
        }
    }
}
