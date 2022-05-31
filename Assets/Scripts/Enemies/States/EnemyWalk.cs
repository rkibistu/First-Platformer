using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : EnemyBaseState {

    public EnemyWalk(EnemyStateMachine stateMachine) : base("Walk", stateMachine) {


    }

    private float patrolTimeCounter;
    private float timeSinceLastCheck; //fara asta, ar verifica distanta maxima in continuu si s ar bloca acolo



    private bool changeToIdle;
    private bool changeToChase;


    public override void Enter() {
        base.Enter();

        patrolTimeCounter = Random.Range(sm.walkTimeMin, sm.walkTimeMax);
        timeSinceLastCheck = 0.1f;
        changeToIdle = false;
        changeToChase = false;

        sm.m_enemy.StartWalk();
        sm.animator.Play(EnemyStateMachine.Animations.Walk.ToString());
    }

    public override void UpdateLogic() {
        base.UpdateLogic();

        if (changeToIdle)
            sm.ChangeState(sm.idleState);
        if (changeToChase && sm.m_enemy.CanChase())
            sm.ChangeState(sm.chaseState);

    }

    public override void UpdatePhysics() {
        base.UpdatePhysics();

        UpdateTimers();

        sm.m_enemy.UpdateWalking();

        CheckMaxDistance();
        CheckPatrolTime();


        if (chaseRectangle.isInside(sm.m_player.transform.position)) {

            changeToChase = true;
        }

    }

    private void CheckMaxDistance() {

        bool maxDistanceAchieved = false;
        if (timeSinceLastCheck > 0.1) {
            if (m_rotation == Rotation.Horizontal) {

                if ((Mathf.Abs(sm.transform.position.x - initialPosition.x) >= sm.maxPatrolDistance)) {
                    maxDistanceAchieved = true; 
                }
            }
            else {
                if ((Mathf.Abs(sm.transform.position.y - initialPosition.y) >= sm.maxPatrolDistance)) { 
                    maxDistanceAchieved = true;
                }
            }
        }

        if (maxDistanceAchieved) {

            sm.m_enemy.SwapDirection();
            timeSinceLastCheck = 0;
        }
    }
    private void CheckPatrolTime() {

        if (patrolTimeCounter <= 0)
            changeToIdle = true;
    }
    private void UpdateTimers() {

        patrolTimeCounter -= Time.fixedDeltaTime;
        timeSinceLastCheck += Time.fixedDeltaTime;
    }

    public override void Exit() {
        base.Exit();

    }


}
