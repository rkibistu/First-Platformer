using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//THIS SCRIPT IS GOING TO:
//   CAPTURE INPUT
//   CONTROL STATE FLOWING


public class PlayerController : MonoBehaviour {

    [HideInInspector]
    public float direction;
    [HideInInspector]
    public bool canJump = false;

    private CollisionDetector collDet;

    

    void Start() {

        collDet = GetComponent<CollisionDetector>();
    }

    // Update is called once per frame
    void Update() {

    }


    void OnMove(InputValue value) {

        direction = value.Get<Vector2>().x;
        print(direction);
    }
    void OnJump() {

        canJump = collDet.isGrounded();
    }

}
