using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossStateMachine : StateMachine
{
    public event EventHandler<CollisionEventArgs> m_CollisionEvent;
    private CollisionEventArgs m_CollisionEventArgs;

    public Transform m_playerTransform;
    public BulletSpawner m_bulletSpawner;

    [HideInInspector]
    public Rigidbody2D m_rigidBody;
    [HideInInspector]
    public Animator m_animator;

    [Header("General")]
    public float m_speed = 1f;
    public int m_maxHealth = 50;
    [HideInInspector]
    public int m_currentHealth;
    
    [HideInInspector]
    public Vector2 m_initialPosition;

    [Header("Before Attack")]
    public float m_randomAngryTime = 2f;
    public float m_randomMovementSpeed = 0.13f;
    public float m_slowlyAngryTime = 2f;
    public float m_slowlyMovementSpeed = 0.06f;

    [Header("Attack")]
    public float m_launchAttackSpeed = 25f;

    [Header("Stunned")]
    public float m_stunDuration = 3f;

    [Header("Walking")]
    public float m_maxWalkingTime = 30f;
    public float m_minWalkingTime = 20f;
    public float m_timeBetweenBullets = 1f;

    [Header("Paths")]
    public List<Vector2> m_path1;
    public List<Vector2> m_path2;


    [HideInInspector]
    public Walking m_walkingState;
    [HideInInspector]
    public Attacking m_attackingState;
    [HideInInspector]
    public Stunned m_stunnedStates;
    [HideInInspector]
    public DeadState m_deadState;

    [HideInInspector]
    public bool m_startMoving = false;

    private void Awake() {

        m_CollisionEventArgs = new CollisionEventArgs();

        m_rigidBody = GetComponent<Rigidbody2D>();
        m_animator = GetComponentInChildren<Animator>();

        m_initialPosition = transform.position;
        m_currentHealth = m_maxHealth;

        m_walkingState = new Walking(this);
        m_attackingState = new Attacking(this);
        m_stunnedStates = new Stunned(this);
        m_deadState = new DeadState(this);
    }


    protected override BaseState GetInitialState() {
        return m_walkingState;
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (m_CollisionEvent != null) {

            m_CollisionEventArgs.collision = collision;
            //m_CollisionEventArgs.collisionBe = (transform.position.y < -0.5);
            m_CollisionEvent(this,m_CollisionEventArgs);
        }
    }

    private void OnDrawGizmosSelected() {
        
        foreach (Vector2 point in m_path1) {

            Gizmos.DrawCube(point, Vector3.one);
        }
    }

    public void GetDamage() {

        m_animator.Play("Hurt");
        m_currentHealth -= 1;

        if (m_currentHealth <= 0)
            ChangeState(m_deadState);
    }

    private void DestroyItself() {

        Destroy(gameObject);
    }

    public void Afis(string x) {
        print(x);
    }
}


//
public class CollisionEventArgs : EventArgs {

    public Collision2D collision { get; set; }

    public bool collisionBelow { get; set; }
}
