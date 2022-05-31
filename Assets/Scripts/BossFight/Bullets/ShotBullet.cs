using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour {

    private Rigidbody2D m_rigidbody;
    private Transform m_player;

    [SerializeField]
    private float m_speed = 10f;
    [SerializeField]
    private float m_turnAccuracy = 10f;
    [SerializeField]
    private int m_damage = 1;

    private bool m_follow = false;

    void Start() {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        m_rigidbody.drag = 0;
        m_rigidbody.gravityScale = 0;

        if (m_follow)
            StartCoroutine(ChangeDirection());
        else {

            LootAtPlayer();
            m_rigidbody.velocity = (m_player.transform.position - transform.position).normalized * m_speed;
        }
    }

    private void LootAtPlayer() {

        Vector3 difference = m_player.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }

    IEnumerator ChangeDirection() {

        while (true) {

            LootAtPlayer();
            m_rigidbody.velocity = (m_player.position - transform.position).normalized * m_speed;

            yield return new WaitForSeconds((float)1 / m_turnAccuracy);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<PlayerStatsHandler>().Damage(m_damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "playerHit") {

            Destroy(gameObject);
        }

    }
}
