using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : WalkingEnemy
{

    int m_rotation;
    public Worm(EnemyStats enemyStats) : base(enemyStats) {

        CalculateMovementParameters();

        canChase = false;
    }

    public override void UpdateWalking() {
        base.UpdateWalking();

        

        switch (m_rotation) {
            case 0:
                //0 grade -> sta normal
                if (!m_collDet.isBottomCornerOnGround(m_rigidbody.velocity)) {

                    //m_enemyStats.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    SwapDirection();
                }
                break;
            case 1:
                //90 grade -> sta pe peretele din dreapta lui
                if (!m_collDet.isRightCornerOnGround(m_rigidbody.velocity)) {
                    //m_enemyStats.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                    SwapDirection();
                }
                break;
            case 2:
                //180 grade -> sta pe tavan
                if (!m_collDet.isUpperCornerOnGround(m_rigidbody.velocity)) {
                    //m_enemyStats.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                    SwapDirection();
                }
                break;
            case 3:
                //270 grade -> sta pe epretele din stanga lui
                if (!m_collDet.isLeftCornerOnGround(m_rigidbody.velocity)) {
                    //m_enemyStats.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                    SwapDirection();
                }
                break;
            default:
                break;
                 
        }

        if (Mathf.Sign(m_rigidbody.velocity.y) != Mathf.Sign(m_direction.y))
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x , m_rigidbody.velocity.y * (-1));
        if (Mathf.Sign(m_rigidbody.velocity.x) != Mathf.Sign(m_direction.x))
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x * (-1), m_rigidbody.velocity.y);
    }
 
    
    private void CalculateMovementParameters() {

        m_rotation = Mathf.RoundToInt(m_transform.rotation.eulerAngles.z);
        if (m_rotation != 0) {

            m_rotation = Mathf.Abs(m_rotation / 90 % 4);
        }

        switch (m_rotation) {
            case 0:
                m_direction = new Vector2(1f, 0f);
                break;
            case 1:
                m_direction = new Vector2(0f, 1f);
                break;
            case 2:
                m_direction = new Vector2(1f, 0f);
                break;
            case 3:
                m_direction = new Vector2(0f, 1f);
                break;
            default:
                m_direction = new Vector2(0f, 0f);
                
                break;
        }
        
    }

    public override void Chase(Vector2 targetPosition) {
        throw new System.NotImplementedException();
    }
}
