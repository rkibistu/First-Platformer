using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Mushroom {

    public Goblin(EnemyStats enemyStats) : base(enemyStats) {

        m_direction = new Vector2(1f, 0f);

        canChase = true;
    }

    public override void Chase(Vector2 targetPosition) {

        bool stop = false;
        if (targetPosition.x + m_enemyStats.chaseTurnAround < m_transform.position.x) {

            m_direction = Vector2.left;
            //m_rigidbody.velocity = m_direction * m_enemyStats.speed;
            if (m_collDet.isLeftCornerOnGround(m_direction))
                stop = true;
        }
        else if (targetPosition.x > m_transform.position.x + m_enemyStats.chaseTurnAround) {

            m_direction = Vector2.right;
            if (m_collDet.isRightCornerOnGround(m_direction))
                stop = true;
        }



        SetSpriteDirection();
        if (!stop)
            m_rigidbody.velocity = m_direction * m_enemyStats.speed;
        else
            m_rigidbody.velocity = Vector2.zero;
    }
}
