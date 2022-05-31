using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStateMachine : EnemyStateMachine_BASE {

    [HideInInspector]
    public GameObject m_player;

    public enum EnemyTypes {  Mushroom = 0, Worm, Goblin}
    public EnemyTypes enemyType;

    public CEnemy m_enemy;
    //--------------------------

    [Header("General")]
    public float idleTime = 3f;
    public float waitAfterDead = 1f;

    [Header("Walk State")]
    [Tooltip("Get random value in this range. The result is the time before he change from walk state to idle state if no other criterion has been met")]
    public float walkTimeMin = 3f;
    public float walkTimeMax = 7f;
    [Tooltip("never travel more than this distance, compared with starting point")]
    public float maxPatrolDistance = 6f;
    //-------------------------------
    [Header("Attack")]
    [Tooltip("Chase distance is equal with patrol distance. We need to know how far in the air can enemy see the player")]
    public float chaseHeight = 1f;

    [Header("Gizmos")]
    public bool patrolPerimeter = false;
    public bool chasePerimeter = false;

    [HideInInspector]
    public EnemyIdle idleState;
    [HideInInspector]
    public EnemyWalk movingState;
    [HideInInspector]
    public EnemyChase chaseState;
    [HideInInspector]
    public EnemyDead deadState;
    [HideInInspector]
    public Animator animator;
    public enum Animations { Idle = 0, Walk, Damaged, Dead };

    [HideInInspector]
    public AudioSource audio;

    private void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");

        CreateEnemy();

        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        idleState = new EnemyIdle(this);
        movingState = new EnemyWalk(this);
        chaseState = new EnemyChase(this);
        deadState = new EnemyDead(this);
    }


    protected override BaseState_Enemy GetInitialState() {
        return idleState;
    }


    private void CreateEnemy() {

        if (enemyType == EnemyTypes.Mushroom)
            m_enemy = new Mushroom(GetComponent<EnemyStats>());
        else if (enemyType == EnemyTypes.Worm)
            m_enemy = new Worm(GetComponent<EnemyStats>());
        else if (enemyType == EnemyTypes.Goblin)
            m_enemy = new Goblin(GetComponent<EnemyStats>());
        
    }

    protected void SetAsInactive() {

        gameObject.SetActive(false);
    }
}
