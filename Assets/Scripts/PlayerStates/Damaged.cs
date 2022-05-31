using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaged : PlayerBaseState
{
    public Damaged(MovementSM stateMachine) : base("Damaged", stateMachine) {

    }

    private float damagedTimeCounter;
    public override void Enter() {
        base.Enter();

        damagedTimeCounter = sm.damagedTimed;
        invincible = true;


        sm.rigidBody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        sm.animator.Play(MovementSM.Animations.Player_Damaged.ToString());
        sm.animator.SetInteger("currentState", 5);
    }

    public override void UpdateLogic() {
        base.UpdateLogic();

        if (damagedTimeCounter <= 0)
            sm.ChangeState(sm.idleState);
    }

    public override void UpdatePhysics() {
        base.UpdatePhysics();

        damagedTimeCounter -= Time.fixedDeltaTime;
    }

    public override void Exit() {
        base.Exit();

        invincible = false;
    }
}
