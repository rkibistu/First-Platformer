using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Fall : inAir {


    //vrem ca player sa paote sari si dupoa o fractiune de secunda ce a parasit pamantul
    //controlul se simte mai bine asa
    //nu vrem ca acest cod sa fie si in JUMP, ca nu cumva sa se dea 2 impulsuri de saritura
    public Fall(MovementSM stateMachine) : base("Fall", stateMachine) {


    }

    private bool _grounded;

    private float extreGroundedTime_counter;
    private bool _canJump;

    public override void Enter() {
        base.Enter();
        //sm.spriteRenderer.color = Color.cyan;

        _grounded = false;
        sm.rigidBody.gravityScale = sm.gravityScaleFall;

        //initial poate sarii daca in starea anterioara putea facee asta. Dupa ce trece timpul acordat, nu mai poate -> canJump - false;
        _canJump = (sm.wasGroundedLastState == true) ? true : false;
        extreGroundedTime_counter = sm.extraGroundTime;

        sm.animator.Play(MovementSM.Animations.Player_Fall.ToString());
        sm.animator.SetInteger("currentState", 3);
    }

    public override void UpdateLogic() {
        base.UpdateLogic();
        if (_grounded)
            stateMachine.ChangeState(sm.idleState);
        if (_canJump && sm.inputManager.jumpButtonPressed)
            stateMachine.ChangeState(sm.jumpingState);

        setSpriteDirection();
    }

    public override void UpdatePhysics() {
        base.UpdatePhysics();

        _grounded = /*sm.rigidBody.velocity.y <= 0.1 &&*/ (sm.collisionDet.isOnSolidSurface());
        

        if (extreGroundedTime_counter > 0) {

            extreGroundedTime_counter -= Time.fixedDeltaTime;
            if (extreGroundedTime_counter <= 0)
                _canJump = false;
        }
    }

    public override void Exit() {
        base.Exit();
        sm.rigidBody.gravityScale = 1f;

    }
}
