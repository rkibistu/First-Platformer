using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class WalkingEnemy : CEnemy
{
    public WalkingEnemy(EnemyStats enemyStats) : base(enemyStats) {

    }



    public override void StartWalk(Vector2 direction) {

        if (direction != default(Vector2))
            m_direction = direction;

        m_rigidbody.velocity = m_direction * m_enemyStats.speed;
    }
    public override void UpdateWalking() {

        SetSpriteDirection();
    }
    public override void StartIdle() {

        m_rigidbody.velocity = new Vector2(0f, 0f);
    }

    public override void SwapDirection() {

        m_direction *= -1;
    }

}
