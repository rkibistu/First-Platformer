using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunned : BossBaseState
{
    public Stunned(BossStateMachine stateMachine) : base("Stunned", stateMachine) {

    }

    private float m_stunTimer;

    public override void Enter() {
        base.Enter();

        //m_sm.m_rigidBody.velocity = Vector2.zero;
        m_sm.m_rigidBody.drag = 8.5f;
        m_stunTimer = m_sm.m_stunDuration;
    }

    public override void UpdateLogic() {
        base.UpdateLogic();

        if (m_stunTimer <= 0)
            m_sm.ChangeState(m_sm.m_walkingState);
    }
    public override void UpdatePhysics() {
        base.UpdatePhysics();

        m_stunTimer -= Time.fixedDeltaTime;     
    }

    public override void Exit() {
        base.Exit();

        m_sm.m_rigidBody.drag = 0;
    }
}
