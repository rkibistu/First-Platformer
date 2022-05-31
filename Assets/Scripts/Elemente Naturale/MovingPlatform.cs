using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    [SerializeField]
    public Vector2 endPos1 = Vector2.right; //e cel mai mare
    private Vector2 endPos2;
    [SerializeField]
    private float speed = 1f;

    private Vector2 direction;
    [HideInInspector]
    public Vector2 initialPos;

    private float bigX, bigY, smallX, smallY;
    private bool canChange = true;

    private Rigidbody2D rigidBody;
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();

        initialPos = transform.position;

        CalculateVectors();
        CalculateXY();
        rigidBody.velocity = direction * speed;
        rigidBody.velocity *= -1;
    }

    private void CalculateVectors() {

        endPos2 = 2 * initialPos - endPos1;

        direction = new Vector2(endPos1.x - initialPos.x, endPos1.y - initialPos.y);
        direction = direction.normalized; //sa aiba aceeasi viteza mereu
    }
    private void CalculateXY() {

        if (endPos1.x > endPos2.x) {

            bigX = endPos1.x;
            smallX = endPos2.x;
        }
        else {
            bigX = endPos2.x;
            smallX = endPos1.x;
        }

        if (endPos1.y > endPos2.y) {

            bigY = endPos1.y;
            smallY = endPos2.y;
        }
        else {
            bigY = endPos2.y;
            smallY = endPos1.y;
        }

    }

    void Update() {


        Vector2 currentPos = transform.position;

        if(canChange == true) {

            if(bigX == smallX) {
                if(currentPos.y > bigY || currentPos.y < smallY) {
                    rigidBody.velocity *= -1;
                    canChange = false;
                }
            }
            else {
                if(currentPos.x > bigX || currentPos.x < smallX) {
                    rigidBody.velocity *= -1;
                    canChange = false;
                }
            }
        }
        else {
            Invoke("SetCanChange", 0.3f);
        }


    }
    private void SetCanChange() { canChange = true; }



    private void OnDrawGizmosSelected() {


        //Gizmos.DrawLine(transform.position, endPos1);
        //if (Application.isPlaying)
        //    Gizmos.DrawLine(transform.position, 2 * initialPos - endPos1);
        //else
        //    Gizmos.DrawLine(transform.position, 2 * (Vector2)transform.position - endPos1);

        //Gizmos.DrawCube(endPos1, Vector3.one);
    }

}
