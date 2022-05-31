using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Walk : Grounded
{
    public Walk(MovementSM stateMachine) : base("Walk", stateMachine) { }

    private float directionX;

    public override void Enter() {
        base.Enter();
        //sm.spriteRenderer.color = Color.red;
        directionX = sm.inputManager.directionX;

        //vrem sa nu avem linear drag decat atunci cand ne oprim sau cand schimbam directia de mers ca sa evitam alunecarile ca pe gheta
        sm.rigidBody.drag = 0;
        //nu avem nevoie de gravitatie cat ne miscam doar stanga dreapta. In functia de exit o resetam la 1
        sm.rigidBody.gravityScale = 0;
        //aici aveam un bug in care avea velocity.y = jumpForce daca spamam butoanele. Se intampla asta fara sa itnre in jump state.
        //asa ca am resetat velocity.y la 0 ca si asa nu ar trebui sa exista cat timp suntem in starea asta
        sm.rigidBody.velocity = new Vector2(sm.rigidBody.velocity.x, 0f);


        sm.animator.Play(MovementSM.Animations.Player_Run.ToString());
        sm.animator.SetInteger("currentState", 1);
        setSpriteDirection();
    }

    public override void UpdateLogic() {
        base.UpdateLogic();
        directionX = sm.inputManager.directionX;
        //daca nu mai apasam niciun buton trecem la idle state
        if (Mathf.Abs(directionX) == 0)
            stateMachine.ChangeState(sm.idleState);
    }

    public override void UpdatePhysics() {
        base.UpdatePhysics();
        MovePlayer();
    }

    public override void Exit() {
        base.Exit();

        //resetam la starea normala variabilele globale ce afecteza miscarea
        sm.rigidBody.gravityScale = 1;
        sm.rigidBody.drag = 0;
    }

    private void MovePlayer() {

        sm.rigidBody.drag = 0;
        //daca schimbam directia, vrem linear drag mare ca sa evitam efectul de alunecare
        if (hasFlipped()) {
            sm.rigidBody.drag = sm.linearDragToStop;
            setSpriteDirection();
        }

        GameObject movingPlatform = sm.collisionDet.isOnMovingPlatform();
        if (movingPlatform != null) {

            sm.rigidBody.velocity = new Vector2(sm.rigidBody.velocity.x, movingPlatform.GetComponent<Rigidbody2D>().velocity.y);
        }
            sm.rigidBody.AddForce(new Vector2(directionX, 0f) * sm.speed * Time.deltaTime, ForceMode2D.Impulse);
        if (Mathf.Abs(sm.rigidBody.velocity.x) > sm.maxSpeed) {

            sm.rigidBody.velocity = new Vector2(Mathf.Sign(sm.rigidBody.velocity.x) * sm.maxSpeed, sm.rigidBody.velocity.y);
        }
    }
    private bool hasFlipped() {

        if (sm.rigidBody.velocity.x < 0 && directionX > 0)
            return true;
        if (sm.rigidBody.velocity.x > 0 && directionX < 0)
            return true;

        return false;
    }



}
