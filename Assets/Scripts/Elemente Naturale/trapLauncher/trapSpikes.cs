using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapSpikes : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int damage = 1;

    private Vector2 direction;
    private Rigidbody2D rigidBody;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        Vector3 rotation = GetComponentInParent<Transform>().rotation.eulerAngles/90;
        switch (rotation.z) {
            case 0:
                direction = Vector2.down;
                break;
            case 1:
                direction = Vector2.right;
                break;
            case 2:
                direction = Vector2.up;
                break;
            case 3:
                direction = Vector2.left;
                break;
            default:
                print("Rotatiile permise pentru lansator: multiplii intregi de 90");
                break;
        }

        rigidBody.gravityScale = 0;
        rigidBody.velocity = direction * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision) {


        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponent<PlayerStatsHandler>().Damage(damage);
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Collectable")
            Destroy(gameObject);
    }

}
