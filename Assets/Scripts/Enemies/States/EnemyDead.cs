using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : EnemyBaseState {

    public EnemyDead(EnemyStateMachine stateMachine) : base("Dead", stateMachine) {


    }

    public override void Enter() {
        base.Enter();

        //sm.StartCoroutine("destroyAfterSound");

        sm.audio.Play();

        sm.m_enemy.StopMovement();

        sm.animator.Play(EnemyStateMachine.Animations.Dead.ToString());
    }

    IEnumerator destroyAfterSound() {

        
        yield return new WaitForSeconds(0.15f);
    }

    private void deathSound() {

        
    }

}
