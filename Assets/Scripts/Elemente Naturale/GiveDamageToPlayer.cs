using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamageToPlayer : MonoBehaviour
{
    public int damage = 1;

    private BoxCollider2D boxColl;

    void Start()
    {
        boxColl = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.collider.tag == "Player") {

            collision.collider.gameObject.GetComponent<PlayerStatsHandler>().Damage(damage);
        }
    }
}
