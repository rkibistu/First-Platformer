using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Dead : PlayerBaseState
{
    public Dead(MovementSM stateMachine) : base("Dead", stateMachine) {

    }

    public override void Enter() {
        base.Enter();

        StopMovement();
        sm.animator.Play(MovementSM.Animations.Player_Dead.ToString());
        sm.animator.SetInteger("currentState", 4);
        sm.StartCoroutine(PlayDieAnimationAfterTime());

        invincible = true;
    }

    IEnumerator PlayDieAnimationAfterTime() {

        yield return new WaitForSeconds(sm.waitAfterDead);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void StopMovement() {

        sm.rigidBody.velocity = new Vector2(0f, 0f);
    }

    public override void Exit() {
        base.Exit();

        invincible = false;
    }
}
