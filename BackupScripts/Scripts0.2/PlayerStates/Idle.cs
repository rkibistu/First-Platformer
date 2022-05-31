using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Grounded
{
    private float _horizontalInput;

    public Idle(MovementSM stateMachine) : base("Idle", stateMachine) { }

    public override void Enter() {
        base.Enter();
        sm.spriteRenderer.color = Color.black;
        _horizontalInput = 0f;

        sm.rigidbody.drag = sm.linearDragToStop;
        sm.rigidbody.gravityScale = 0;
        
    }

    public override void UpdateLogic() {
        base.UpdateLogic();
        _horizontalInput = sm.inputManager.directionX;
        if (Mathf.Abs(_horizontalInput) != 0)
            stateMachine.ChangeState(sm.movingState);
    }

    public override void Exit() {
        base.Exit();

        sm.rigidbody.drag = 0;
        sm.rigidbody.gravityScale = 1;
    }
}
