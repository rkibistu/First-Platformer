using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    [HideInInspector]
    public float directionX = 0f;
    [HideInInspector]
    public bool jumpButtonPressed = false;
    [HideInInspector]
    public float directionY = 0f;
    [HideInInspector]
    public bool attackButtonPressed = false;
    [HideInInspector]
    public bool dashButtonPressed = false;
    [HideInInspector]
    public bool escButtonPressed = false;

    [SerializeField]
    private float jumpButtonTimer = 0.1f;
    private float jumpButtonCounter;

    [SerializeField]
    private float dashCooldown = 2f;
    private float dashCooldownTimer = 0f;


    static public InputManager Instance { get; private set; }


    private void Awake() {
        
        Instance = this; //doar la finalul proiectului am relizat ca pot sa fac asta, si n am 

    }
    void Start() {
        jumpButtonCounter = jumpButtonTimer;

    }

    // Update is called once per frame
    void Update() {
        JumpButtonFinesse();

        UpdateTimers();
    }

    private void UpdateTimers() {

        if(dashCooldownTimer > 0)
            dashCooldownTimer -= Time.deltaTime;
    }

    private void JumpButtonFinesse() {
        //nu e nevoie sa apesi space fix in fram-ul in care se face contact cu pamantu
        //face sa mearga mai dragut cand fugi si sari incontinuu
        // evita sa se intample asta: apesi space si nu sare
        if (jumpButtonPressed == true) {

            jumpButtonCounter -= Time.deltaTime;
            if (jumpButtonCounter <= 0) {

                jumpButtonPressed = false;
                jumpButtonCounter = jumpButtonTimer;
            }
        }
        else {
            jumpButtonCounter = jumpButtonTimer;
        }
    }

    void OnMove(InputValue value) {

        directionX = value.Get<Vector2>().x;
        directionY = value.Get<Vector2>().y;
    }
    void OnJump() {

        jumpButtonPressed = true;
    }

    void OnAttack() {

        attackButtonPressed = true;
    }

    void OnDash() {

        if (dashCooldownTimer <= 0) {
            dashButtonPressed = true;
            dashCooldownTimer = dashCooldown;
        }
    }
    void OnEsc() {

        escButtonPressed = true;
    }

    public bool CanJump() { return dashCooldownTimer <= 0; }
    public float GetDashCooldown() { return dashCooldown; }
    public float GetDashCooldownTimer() { return dashCooldownTimer; }
}
