using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{

    public float speed = 20f;
    public float maxSpeed = 55f;
    public float jumpForce = 14f;
    public float linearDragToStop = 10f;
    [HideInInspector]
    public Rigidbody2D rigidbody;
    [HideInInspector]
    public SpriteRenderer spriteRenderer;
    [HideInInspector]
    public InputManager inputManager;
    [HideInInspector]
    public CollisionDetector collisionDet;

    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Walk movingState;
    [HideInInspector]
    public Jump jumpingState;

    private void Awake() {

        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        inputManager = GetComponent<InputManager>();
        collisionDet = GetComponent<CollisionDetector>();

        idleState = new Idle(this);
        movingState = new Walk(this);
        jumpingState = new Jump(this);
    }

    protected override BaseState GetInitialState() {
        return idleState;
    }



}
