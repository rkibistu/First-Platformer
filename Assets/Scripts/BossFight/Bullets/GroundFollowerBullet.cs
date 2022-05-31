using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFollowerBullet : MonoBehaviour
{
    private Rigidbody2D m_rigidBody;
    private Animator m_animator;
    private GameObject m_player;

    [SerializeField]
    private int m_damage;
    [SerializeField]
    private float m_speed;


    private bool m_grounded;
    private float directionX;
    void Start()
    {

        m_rigidBody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_player = GameObject.FindGameObjectWithTag("Player");

        m_grounded = false;
    }

    
    void Update()
    {
        if (m_grounded) {

            if (HasChangedDirection())
                Invoke("ChangeVelocity", 0.3f);
        }      
    }

    private void SetDirection() {

        if (m_player.transform.position.x < transform.position.x)
            directionX = -1;
        else directionX = 1;
    }
    private bool HasChangedDirection() {

        float oldDirection = directionX;
        SetDirection();

        return oldDirection != directionX;
    }
    private void ChangeVelocity() {

        m_rigidBody.velocity = new Vector2(directionX * m_speed, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        


        if(collision.gameObject.tag == "Ground") {

            m_grounded = true;
            m_rigidBody.drag = 0;
            m_rigidBody.gravityScale = 0;
        }
        else if(collision.gameObject.tag == "playerHit") {

            print("hit");
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Player") {
            print("player");
            m_player.GetComponent<PlayerStatsHandler>().Damage(m_damage);
            m_animator.Play("Dead");
        }
        
    }

    private void AutoDestroy() {

        Destroy(gameObject);
    }

}
