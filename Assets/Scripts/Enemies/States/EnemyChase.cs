using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyBaseState
{

    public EnemyChase(EnemyStateMachine stateMachine) : base("Chase", stateMachine) {

    }

    private bool changeToIdle;

    public override void Enter() {
        base.Enter();

        changeToIdle = false;
        sm.m_enemy.Chase(sm.m_player.transform.position);

        //eventual verifica si daca vechea stare era tot walk, nu mai reincepe aniamtia
        sm.animator.Play(EnemyStateMachine.Animations.Walk.ToString());
    }

    public override void UpdateLogic() {
        base.UpdateLogic();

        if (changeToIdle)
            sm.ChangeState(sm.idleState);
    }


    public override void UpdatePhysics() {
        base.UpdatePhysics();

        sm.m_enemy.Chase(sm.m_player.transform.position);

        CheckChasePerimeter();
    }

    private void CheckChasePerimeter() {

        if (!chaseRectangle.isInside(sm.m_player.transform.position))
            changeToIdle = true;
        
    }

}
