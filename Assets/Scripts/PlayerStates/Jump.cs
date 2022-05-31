using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Jump : inAir
{
    public Jump(MovementSM stateMachine) : base("Jump", stateMachine) {
    }

    private bool startFalling;

    public override void Enter() {
        base.Enter();
        //sm.spriteRenderer.color = Color.green;
        startFalling = false;

        sm.inputManager.jumpButtonPressed = false;
        sm.rigidBody.AddForce(new Vector2(0f, 1f) * sm.jumpForce, ForceMode2D.Impulse);

        sm.rigidBody.drag = sm.linearDragAir;
        sm.rigidBody.gravityScale = sm.gravityScaleJump;

        sm.animator.Play(MovementSM.Animations.Player_Jump.ToString());
        sm.animator.SetInteger("currentState", 2);
    }

    public override void UpdateLogic() {
        base.UpdateLogic();
        if (startFalling)
            stateMachine.ChangeState(sm.fallingState);

        setSpriteDirection();
    }

    public override void UpdatePhysics() {
        base.UpdatePhysics();
        if (sm.rigidBody.velocity.y < 0)
            startFalling = true;
    }


}
