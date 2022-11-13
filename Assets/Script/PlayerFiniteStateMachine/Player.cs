using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
#region State Variables
    public PlayerStateMachine stateMachine {get; private set;}
    public PlayerIdleState IdleState {get;private set;}
    public PlayerMoveState MoveState {get;private set;}
    public PlayerJumpUpState JumpUpState {get;private set;}
    public PlayerJumpStayState JumpStayState {get;private set;}
    public PlayerJumpDownState JumpDownState {get;private set;}
    [SerializeField]
    private PlayerData playerData;
#endregion

#region Components
    public Animator Anim {get; private set;}
    public PlayerInputHandler InputHandler {get; private set;}
    public Rigidbody2D rb {get; private set;}
#endregion

    public Vector2 CurrentVelocity {get;private set;}

    public int FacingDirection{get; private set;}


    private Vector2 workspace;

    private void Awake() {
        stateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, stateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, stateMachine, playerData, "move");
        JumpUpState = new PlayerJumpUpState(this, stateMachine, playerData, "jumpUp");
        JumpDownState = new PlayerJumpDownState(this, stateMachine, playerData, "jumpDown");
        JumpStayState = new PlayerJumpStayState(this, stateMachine, playerData, "jumpStay");
    }
    private void Start() {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();
        FacingDirection = 1;


        stateMachine.Init(IdleState);
    }
    private void Update() {
        stateMachine.currentState.LogicUpdate();
        CurrentVelocity = rb.velocity;
    }
    private void FixedUpdate() {
        stateMachine.currentState.PhysicUpdate();
    }
    public void SetVelocityX(float velocity){
        workspace.Set(velocity,CurrentVelocity.y);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }
    public void SetVelocityY(float velocity){
        workspace.Set(CurrentVelocity.x,velocity);
    }

    public void CheckIfShouldFlip(int Xinput){
        if(Xinput != 0 && Xinput != FacingDirection){
            Flip();
        }
    }

    private void Flip(){
        FacingDirection *= -1;
        transform.Rotate(0.0f,180.0f,0.0f);
    }
}
