using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : WalkingEnemy
{
    public Mushroom(EnemyStats enemyStats) : base(enemyStats) {

        m_direction = new Vector2(1f, 0f);

        canChase = false;
    }

    public override void UpdateWalking() {
        base.UpdateWalking();
        if (!m_collDet.isBottomCornerOnGround(m_rigidbody.velocity)) {

            SwapDirection();
        }
        if(Mathf.Sign(m_rigidbody.velocity.x) != Mathf.Sign(m_direction.x))
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x * (-1), m_rigidbody.velocity.y);
    }


    public override void Chase(Vector2 targetPosition) {
        throw new System.NotImplementedException();
    }
}
