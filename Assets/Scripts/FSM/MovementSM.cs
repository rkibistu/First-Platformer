using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    [Header("Ground")] 
    public float speed = 20f;
    public float maxSpeed = 55f;
    public float linearDragToStop = 10f;
    [Header("Air")] 
    public float jumpForce = 14f;
    public float extraGroundTime = 0.2f;
    [HideInInspector]
    public bool wasGroundedLastState;
    public float linearDragAir = 0.6f;
    public float gravityScaleJump = 1.5f;
    public float gravityScaleFall = 2.5f;
    [Header("Dash")]
    public float dashSpeed = 6f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    [Header("General")]
    public float damagedTimed = 0.3f; //time he stays in damaged state
    public float waitAfterDead = 1f;
    public Animator hitBox;
    [HideInInspector]
    public bool isDead = false;


    [HideInInspector]
    public Transform _transform;
    [HideInInspector]
    public Rigidbody2D rigidBody;
    [HideInInspector]
    public SpriteRenderer spriteRenderer;
    [HideInInspector]
    public InputManager inputManager;
    [HideInInspector]
    public CollisionDetector collisionDet;
    [HideInInspector]
    public Animator animator;
    public enum Animations { Player_Idle = 0, Player_Run, Player_Jump, Player_Fall, Player_Dead, Player_Damaged, Player_Attack};

 
    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Walk movingState;
    [HideInInspector]
    public Jump jumpingState;
    [HideInInspector]
    public Fall fallingState;
    [HideInInspector]
    public Dead deadState;
    [HideInInspector]
    public Damaged damagedState;
    [HideInInspector]
    public Dash dashState;

    [HideInInspector]
    protected PlayerBaseState m_currentState;

    [HideInInspector]
    public playerAudio playerAudio;

    private void Awake() {

        _transform = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        inputManager = GetComponent<InputManager>();
        collisionDet = GetComponent<CollisionDetector>();
        animator = GetComponent<Animator>();

        idleState = new Idle(this);
        movingState = new Walk(this);
        jumpingState = new Jump(this);
        fallingState = new Fall(this);
        deadState = new Dead(this);
        damagedState = new Damaged(this);
        dashState = new Dash(this);

        playerAudio = GetComponent<playerAudio>();
    }




    public override void Update() {
        base.Update();

        m_currentState = (PlayerBaseState)currentState;
    }

    protected override BaseState GetInitialState() {
        return idleState;
    }

    public bool IsInvincible() {

        return m_currentState.invincible;
    }

    public void Afiseaza(string mesaj) {

        print(mesaj);
    }
    
}

