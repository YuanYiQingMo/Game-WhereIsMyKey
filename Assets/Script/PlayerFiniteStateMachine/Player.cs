using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerJumpStayState JumpStayState { get; private set; }
    public PlayerJumpDownState JumpDownState { get; private set; }
    public PlayerLandState LandState {get;private set;}
    [SerializeField]
    private PlayerData playerData;
    #endregion

    #region Components Variables
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    #region Move Variables
    public Vector2 CurrentVelocity { get; private set; }

    public int FacingDirection { get; private set; }
    private Vector2 workspace;
    #endregion

    #region Unity CallbackFunction

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, stateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, stateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, stateMachine, playerData, "jump");
        JumpDownState = new PlayerJumpDownState(this, stateMachine, playerData, "jumpDown");
        JumpStayState = new PlayerJumpStayState(this, stateMachine, playerData, "jumpStay");
        LandState = new PlayerLandState(this, stateMachine, playerData, "land");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();
        FacingDirection = 1;


        stateMachine.Init(IdleState);
    }

    private void Update()
    {
        stateMachine.currentState.LogicUpdate();
        CurrentVelocity = rb.velocity;
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.PhysicUpdate();
    }

    #endregion

    #region Other

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    #endregion

    #region CheckFunction

    public void CheckIfShouldFlip(int Xinput)
    {
        if (Xinput != 0 && Xinput != FacingDirection)
        {
            Flip();
        }
    }

    public bool CheckCanJump()
    {
        return true;
    }

    #endregion
}
