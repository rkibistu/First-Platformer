using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CEnemy : IEnemy
{
    protected EnemyStats m_enemyStats;
    public Rigidbody2D m_rigidbody;
    public Transform m_transform;
    public CollisionDetector m_collDet;

    protected Vector2 m_direction;

    protected bool canChase;

    public CEnemy(EnemyStats enemyStats) {

        m_enemyStats = enemyStats;
        m_rigidbody = enemyStats.gameObject.GetComponent<Rigidbody2D>();
        m_transform = enemyStats.gameObject.GetComponent<Transform>();
        m_collDet = enemyStats.gameObject.GetComponent<CollisionDetector>();
    }

    abstract public void StartWalk(Vector2 direction = default(Vector2));
    abstract public void UpdateWalking();
    abstract public void StartIdle();
    abstract public void SwapDirection();

    abstract public void Chase(Vector2 targetPosition);
    public bool CanChase() { return canChase; }

    public void SetSpriteDirection() {

        float spriteDirection = m_transform.localScale.x;
        if (m_rigidbody.velocity.x != 0)
            spriteDirection = (m_rigidbody.velocity.x < 0) ? -1 : 1;
        m_transform.localScale = new Vector3(spriteDirection, m_transform.localScale.y, m_transform.localScale.z);
    }
    public void StopMovement() {

        m_rigidbody.velocity = new Vector2(0f, 0f);
    }
}
