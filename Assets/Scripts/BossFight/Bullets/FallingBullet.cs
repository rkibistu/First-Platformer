using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBullet : MonoBehaviour
{

    private Rigidbody2D m_rigidBody;

    [SerializeField]
    private int m_damage;
    [SerializeField]
    private float m_speed;

    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = m_speed;
    }
    

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if(collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<PlayerStatsHandler>().Damage(m_damage);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "playerHit") {

            Destroy(gameObject);
        }
    }
}
