using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Grounded
{
    private float _horizontalInput;

    public Idle(MovementSM stateMachine) : base("Idle", stateMachine) { }

    public override void Enter() {
        base.Enter();
        //sm.spriteRenderer.color = Color.black;
        _horizontalInput = 0f;

        //vrem linear drag mare sa evitam efectul de alunecare la oprire
        sm.rigidBody.drag = sm.linearDragToStop;
        //nu avem nevoie de gravitatie. Resetam la final
        sm.rigidBody.gravityScale = 0;
        //evitam un bug(vezi la walk state, acelasi lucru explicat)
        sm.rigidBody.velocity = new Vector2(sm.rigidBody.velocity.x, 0f);


        sm.animator.Play(MovementSM.Animations.Player_Idle.ToString());
        sm.animator.SetInteger("currentState", 0);
    }

    public override void UpdateLogic() {
        base.UpdateLogic();
        _horizontalInput = sm.inputManager.directionX;
        if (Mathf.Abs(_horizontalInput) != 0) 
            stateMachine.ChangeState(sm.movingState);
        
    }

    public override void UpdatePhysics() {
        base.UpdatePhysics();

        GameObject movingPlatform = sm.collisionDet.isOnMovingPlatform();
        if (movingPlatform != null) {

            sm.rigidBody.velocity = movingPlatform.GetComponent<Rigidbody2D>().velocity;

            sm.rigidBody.drag = 0;
            //sm.rigidBody.gravityScale = 0;
        }
    }


    public override void Exit() {
        base.Exit();

        //resetam variabilele pentru miscare
        sm.rigidBody.drag = 0;
        sm.rigidBody.gravityScale = 1;
    }
}
