using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Walk : Grounded
{
    public Walk(MovementSM stateMachine) : base("Walk", stateMachine) { }

    private float directionX;

    public override void Enter() {
        base.Enter();
        sm.spriteRenderer.color = Color.red;
        directionX = sm.inputManager.directionX;

        sm.rigidbody.drag = 0;
        sm.rigidbody.gravityScale = 0;
    }

    public override void UpdateLogic() {
        base.UpdateLogic();
        directionX = sm.inputManager.directionX;
        if (Mathf.Abs(directionX) == 0)
            stateMachine.ChangeState(sm.idleState);
    }

    public override void UpdatePhysics() {
        base.UpdatePhysics();
        MovePlayer();
    }

    public override void Exit() {
        base.Exit();

        sm.rigidbody.gravityScale = 1;
    }

    private void MovePlayer() {

        sm.rigidbody.drag = 0;
        if (hasFlipped()) 
            sm.rigidbody.drag = sm.linearDragToStop;


        sm.rigidbody.AddForce(new Vector2(directionX, 0f) * sm.speed * Time.deltaTime, ForceMode2D.Impulse);
        if (Mathf.Abs(sm.rigidbody.velocity.x) > sm.maxSpeed) {

            sm.rigidbody.velocity = new Vector2(Mathf.Sign(sm.rigidbody.velocity.x) * sm.maxSpeed, sm.rigidbody.velocity.y);
        }
    }
    private bool hasFlipped() {

        if (sm.rigidbody.velocity.x < 0 && directionX == 1)
            return true;
        if (sm.rigidbody.velocity.x > 0 && directionX == -1)
            return true;

        return false;
    }


}
