using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : PlayerBaseState
{
    public Dash(MovementSM stateMachine) : base ("Dash", stateMachine) { }

    private float dashTimer;
    private bool endDash = false;

    public override void Enter() {
        base.Enter();

        dashTimer = sm.dashDuration;

        sm.rigidBody.gravityScale = 0;
        sm.rigidBody.drag = 0;
        sm.rigidBody.velocity = new Vector2(sm.rigidBody.transform.localScale.x * sm.dashSpeed, 0);

        sm.playerAudio.PlayDashSound();
    }

    public override void UpdateLogic() {
        base.UpdateLogic();

        if (endDash)
            sm.ChangeState(sm.idleState);

        AfterImagePool.Instance.GetFromPool();
    }

    public override void UpdatePhysics() {
        base.UpdatePhysics();

        dashTimer -= Time.fixedDeltaTime;
        if (dashTimer <= 0)
            endDash = true;
    }

    public override void Exit() {
        base.Exit();

        sm.rigidBody.velocity = new Vector2(0f, 0f);
        endDash = false;
    }
}
