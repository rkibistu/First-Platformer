using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperObject : MonoBehaviour
{
    [SerializeField]
    private Vector2 jumpForce = Vector2.up;

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.gameObject.tag == "Player") {

            Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRB.velocity = new Vector2(0f, 0f);

            MovementSM playerSM = collision.gameObject.GetComponent<MovementSM>();
            playerSM.ChangeState(playerSM.jumpingState);
            playerRB.AddForce(jumpForce, ForceMode2D.Impulse);
        }
    }
}
