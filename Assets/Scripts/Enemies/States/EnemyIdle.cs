using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyBaseState
{
    public EnemyIdle(EnemyStateMachine stateMachine) : base("Idle", stateMachine) {


    }

    private float idleTimeCounter;

    public override void Enter() {
        base.Enter();

        idleTimeCounter = sm.idleTime;

        sm.m_enemy.StartIdle();
        sm.animator.Play(EnemyStateMachine.Animations.Idle.ToString());
    }

    public override void UpdateLogic() {
        base.UpdateLogic();

        if(idleTimeCounter <= 0) {

            sm.ChangeState(sm.movingState);
        }
    }

    public override void UpdatePhysics() {
        base.UpdatePhysics();

        idleTimeCounter -= Time.fixedDeltaTime;
    }

}
