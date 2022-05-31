using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : BossBaseState {

    public Walking(BossStateMachine stateMachine) : base("Walking", stateMachine) {

    }

    private List<Vector2> m_currentPath;
    private bool m_hasArrived = true;
    private int m_indexPath = 0;

    private float m_maxWalkingTimer;
    private float m_minWalkingTimer;
    private float m_betweenBulletsTimer;

    private float healthProcPhase2 = 0.3f;

    public override void Enter() {
        base.Enter();

        m_currentPath = m_sm.m_path1;
        m_hasArrived = true;
        if((float)m_sm.m_currentHealth < m_sm.m_maxHealth * healthProcPhase2) {

            m_maxWalkingTimer = m_sm.m_maxWalkingTime/1.5f;
            m_minWalkingTimer = m_sm.m_minWalkingTime/1.5f;
            m_betweenBulletsTimer = m_sm.m_timeBetweenBullets + 0.6f;
        }
        else {
            m_maxWalkingTimer = m_sm.m_maxWalkingTime;
            m_minWalkingTimer = m_sm.m_minWalkingTime;
            m_betweenBulletsTimer = m_sm.m_timeBetweenBullets;
        }
        
    }

    public override void UpdateLogic() {
        base.UpdateLogic();

        if(m_sm.m_startMoving == true) {

            if (m_hasArrived == true) {

                m_hasArrived = false;
                GoToPosition(GetNextPointInPath(), m_sm.m_speed, emptyFunc);
            }
            else if (m_minWalkingTimer <= 0) {


                if (m_maxWalkingTimer <= 0)
                    m_sm.ChangeState(m_sm.m_attackingState);

                if (Random.Range(1, 1000) == 5)
                    m_sm.ChangeState(m_sm.m_attackingState);
            }

            if (m_betweenBulletsTimer <= 0) {

                m_betweenBulletsTimer = m_sm.m_timeBetweenBullets;

                SpawnBullets();
            }
        }
    }
    private void SpawnBullets() {

        int type = Random.Range(1, 4);
        switch (type) {
            case 1:
                BulletAttack2();
                break;
            case 2:
                m_sm.m_bulletSpawner.SpawnGroundFollowerBullet();
                break;
            case 3:
                BulletAttack1();
                break;
            default:
                break;
        }
    }
    private void BulletAttack1() {

        
        m_sm.StartCoroutine(BulletAttack1_c());
    }
    IEnumerator BulletAttack1_c() {

        int bulletsNo = ((float)m_sm.m_currentHealth > m_sm.m_maxHealth * healthProcPhase2) ? 5 : 15;

        for (int i = 0; i < bulletsNo; i++) {

            m_sm.m_bulletSpawner.SpawnShotBullet();
            yield return new WaitForSeconds(0.8f);
        }
    }

    private void BulletAttack2() {
        m_sm.StartCoroutine(BulletAttack2_c());
        m_betweenBulletsTimer += 0.5f;
    }
    IEnumerator BulletAttack2_c() {

        int bulletsNo = ((float)m_sm.m_currentHealth > m_sm.m_maxHealth * healthProcPhase2) ? 1 : 3;
        for (int i = 0; i < bulletsNo; i++) {

            m_sm.m_bulletSpawner.SpawnFallingBullets(31);
            yield return new WaitForSeconds(1.3f);
        }
    }

    public override void UpdatePhysics() {
        base.UpdatePhysics();

        if (m_sm.m_startMoving) {

            m_maxWalkingTimer -= Time.fixedDeltaTime;
            m_betweenBulletsTimer -= Time.fixedDeltaTime;
            m_minWalkingTimer -= Time.fixedDeltaTime;
        }
        
    }

    Vector2 GetNextPointInPath() {

        m_indexPath++;
        if (m_indexPath >= m_currentPath.Count)
            m_indexPath = 0;
        return m_currentPath[m_indexPath];
    }

    int emptyFunc() {
        m_hasArrived = true;
        return 0;
    }


    public override void Exit() {
        base.Exit();

    }
}
