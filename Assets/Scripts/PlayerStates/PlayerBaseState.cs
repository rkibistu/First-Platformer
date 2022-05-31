using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : BaseState {
    protected MovementSM sm;
    public PlayerBaseState(string name, MovementSM stateMachine) : base(name, stateMachine) {

        sm = (MovementSM)this.stateMachine;
    }

    public bool invincible;


    public override void UpdateLogic() {
        base.UpdateLogic();

        if (sm.inputManager.CanJump()) {
            //ceva sa stii ca poti da dash
            sm.spriteRenderer.color = Color.yellow;
        }
        else {
            sm.spriteRenderer.color = new Color(1f, 1f, 1f);
        }


        if (sm.isDead)
            sm.ChangeState(sm.deadState);
        if (sm.inputManager.dashButtonPressed)
            PlayerDash();
    }

    public override void UpdatePhysics() {
        base.UpdatePhysics();

        if (sm.inputManager.attackButtonPressed)
            PlayerAttack();


    }


    public void setSpriteDirection() {

        float spriteDirection = sm._transform.localScale.x;
        if (sm.inputManager.directionX != 0)
            spriteDirection = (sm.inputManager.directionX > 0) ? 1 : -1;
        sm._transform.localScale = new Vector3(spriteDirection, sm._transform.localScale.y, sm._transform.localScale.z);
    }

    protected void PlayerAttack() {

        sm.inputManager.attackButtonPressed = false;

        sm.playerAudio.PlaySwordSound();
        sm.hitBox.Play("hit");
        sm.animator.Play(MovementSM.Animations.Player_Attack.ToString());
    }
    protected void PlayerDash() {

        sm.inputManager.dashButtonPressed = false;
        sm.ChangeState(sm.dashState);
    }
}
