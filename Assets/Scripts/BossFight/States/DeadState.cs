using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : BossBaseState {
    public DeadState(BossStateMachine stateMachine) : base("Dead", stateMachine) {

    }

    public override void Enter() {
        base.Enter();

        m_sm.m_animator.Play("Dead");
    }
}
