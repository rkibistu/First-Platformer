using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inAir : PlayerBaseState
{
    private float directionX;

    
    public inAir(string name, MovementSM stateMachine) : base(name, stateMachine) {

        
    }

    public override void Enter() {
        base.Enter();

        invincible = false;
    }

    public override void UpdateLogic() {
        base.UpdateLogic();

        directionX = sm.inputManager.directionX;
        
    }

    public override void UpdatePhysics() {
        base.UpdatePhysics();

        sm.rigidBody.AddForce(new Vector2(directionX, 0f) * sm.speed * Time.deltaTime, ForceMode2D.Impulse);
        if (Mathf.Abs(sm.rigidBody.velocity.x) > sm.maxSpeed) {

            sm.rigidBody.velocity = new Vector2(Mathf.Sign(sm.rigidBody.velocity.x) * sm.maxSpeed, sm.rigidBody.velocity.y);
        }
    }

    public override void Exit() {
        base.Exit();

        sm.wasGroundedLastState = false;
    }

}
