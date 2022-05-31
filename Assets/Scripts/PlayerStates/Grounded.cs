using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grounded : PlayerBaseState
{
    //Starea asta e parinte la toate starile ce se itnampla pe pamant
    //Facem asta ca sa nu repetam cod.
    //de exemplu codul epntru schimbarea sarii in JUMPING;

    public Grounded(string name, MovementSM stateMachine) : base(name, stateMachine) {

    }
    public override void Enter() {
        base.Enter();

        invincible = false;
    }

    public override void UpdateLogic() {
        base.UpdateLogic();
        if (sm.inputManager.jumpButtonPressed && sm.collisionDet.isOnSolidSurface())
            stateMachine.ChangeState(sm.jumpingState);
        if (!sm.collisionDet.isOnSolidSurface())
            stateMachine.ChangeState(sm.fallingState);
    }

    public override void Exit() {
        base.Exit();

        sm.wasGroundedLastState = true;
    }

}
