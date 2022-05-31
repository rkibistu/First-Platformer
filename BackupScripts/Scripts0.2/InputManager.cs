using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [HideInInspector]
    public float directionX = 0f;
    [HideInInspector]
    public bool jumpButtonPressed = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMove(InputValue value) {

        directionX = value.Get<Vector2>().x;
    }
    void OnJump() {

        jumpButtonPressed = true;
    }
}
