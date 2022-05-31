using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossBaseState : BaseState {
    protected BossStateMachine m_sm;
    public BossBaseState(string name, BossStateMachine stateeMachine) : base(name, stateeMachine) {

        m_sm = (BossStateMachine)this.stateMachine;
    }

    protected AnimationClip m_clip;


    public override void StateStart() {
        base.StateStart();
    }

    public override void Enter() {
        base.Enter();

        m_sm.m_rigidBody.gravityScale = 0;
        m_sm.m_rigidBody.drag = 0;
    }
    public override void UpdateLogic() {
        base.UpdateLogic();

    }
    public override void UpdatePhysics() {
        base.UpdatePhysics();
    }
    public override void Exit() {
        base.Exit();
    }


    //Miscare aleatorie circulara, termianta cu o ridicare in sus(ca o pregatire de atac), apoi efectueaza o functie daca ca parametru
    protected void AngryMovement(Func<int> DoAfter) {

        m_sm.StartCoroutine(RandomLocalMovement(m_sm.m_randomAngryTime, m_sm.m_slowlyAngryTime, DoAfter));
    }
    protected int LaunchYourselfToPlayer() {

        SetVelocityToGoOnPoint(m_sm.m_playerTransform.position, m_sm.m_launchAttackSpeed);
        m_sm.m_CollisionEvent += OnCollisionEvent;

        return 0;
    }
    protected int GoToPosition(Vector2 position, float speed, Func<int> DoAfter) {

        m_sm.StartCoroutine(GoToPositionCourutine(position, speed, DoAfter));
        return 0;
    }

    IEnumerator RandomLocalMovement(float randomMovementTime, float slowlyMovementTime, Func<int> DoAfter) {

        //se va misca aleator timp de randomMovementTime
        //apoi se va ridica incet in sus timp de slowlyMovementTime

        float randomMovementSpeed = m_sm.m_randomMovementSpeed / 100f;
        float slowlyMovementSpeed = m_sm.m_slowlyMovementSpeed / 100f;

        float counter = 0f;

        while (counter < randomMovementTime) {


            counter += Time.deltaTime;

            m_sm.transform.position = m_sm.transform.position + UnityEngine.Random.insideUnitSphere * randomMovementSpeed;
            yield return null;
        }

        counter = 0f;
        while (counter < slowlyMovementTime) {

            counter += Time.deltaTime;

            m_sm.transform.position = m_sm.transform.position + new Vector3(0f, slowlyMovementSpeed, 0f);
            yield return null;
        }

        DoAfter();
    }
    IEnumerator GoToPositionCourutine(Vector3 position, float speed, Func<int> DoAfter) {

        //m_GoingToPosCourutine = true;

        Vector2[] POS = GetRoundedPointsAround(position);

        bool loop = true;
        while (loop) {

            SetVelocityToGoOnPoint(position, speed);

            Vector2 currentPos = GeneralUtil.Round((Vector2)m_sm.transform.position, 1);

            for (int i = 0; i < 9; i++) {

                if (POS[i] == currentPos) {
                    loop = false;
                    break;
                }
            }
            yield return null;
        }

        m_sm.m_rigidBody.velocity = Vector2.zero;

        DoAfter();
    }


    void OnCollisionEvent(object sender, CollisionEventArgs e) {

        if (e.collision.gameObject.tag == "Player") {

            m_sm.Afis("Collide with Player");
            m_sm.ChangeState(m_sm.m_walkingState);
        }
        else if ((e.collision.gameObject.tag == "Ground")) {

            m_sm.Afis("Collide with Ground");
            m_sm.ChangeState(m_sm.m_stunnedStates);
        }

        m_sm.m_CollisionEvent -= OnCollisionEvent;
    }


    private void SetVelocityToGoOnPoint(Vector3 position, float speed) {

        Vector2 velocity = position - m_sm.transform.position;
        velocity = velocity.normalized * speed;

        m_sm.m_rigidBody.velocity = velocity;
    }
    private Vector2[] GetRoundedPointsAround(Vector2 position) {

        //pentru (1.34,2.45) => 
        // 1.2,2.3  1.2,2.4  1.2,2.5
        // 1.3,2.3  1.3,2.4  1.3,2.5
        // 1.4,2.3  1.4,2.4  1.4,2.5

        float[] X = new float[3];
        float[] Y = new float[3];
        Vector2[] POS = new Vector2[9];
        int counter = 0;
        for (float i = -0.1f; i <= 0.1f; i = i + 0.1f) {

            Vector2 temp;
            temp.x = position.x + i;
            for (float j = -0.1f; j <= 0.1f; j = j + 0.1f) {

                temp.y = position.y + j;
                POS[counter++] = GeneralUtil.Round(temp, 1);
            }
        }

        return POS;
    }
}
