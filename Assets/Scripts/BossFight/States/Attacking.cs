using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : BossBaseState
{

    public Attacking(BossStateMachine stateMachine) : base("Attacking", stateMachine) {

    }

    public override void Enter() {
        base.Enter();

        m_sm.StopAllCoroutines();
        

        m_sm.m_rigidBody.velocity = Vector2.zero;

        AngryMovement(LaunchYourselfToPlayer);
    }

    public override void UpdateLogic() {
        base.UpdateLogic();

    }



    public override void Exit() {
        base.Exit();



        //m_sm.m_rigidBody.velocity = Vector2.zero;
    }
}
