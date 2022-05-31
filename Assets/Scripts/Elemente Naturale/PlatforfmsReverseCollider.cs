using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatforfmsReverseCollider : MonoBehaviour {

    public LayerMask playerMask;
    private PlatformEffector2D platformEffector;
    private Collider2D _collider;

    public float resetTime = 0.5f;

    private float waitTime = 0f;
    private bool hasStarted = false;
    private bool reset = false;

    int defaultMask = 0; //default
    int platformMask = 6; //platform
    int colliderMask_enabled;
    int colliderMask_disabled;

    void Start() {
        platformEffector = GetComponent<PlatformEffector2D>();
        _collider = GetComponent<Collider2D>();

        colliderMask_enabled = LayerMask.GetMask("Player", "Enemy");
        colliderMask_disabled = LayerMask.GetMask("Enemy");
    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {

            waitTime = resetTime;

            if (!hasStarted) {

                hasStarted = true;

                //set layer mask
                gameObject.layer = defaultMask;
                platformEffector.colliderMask = colliderMask_disabled;
            }

        }

        if (waitTime > 0)
            waitTime -= Time.deltaTime;

        if (waitTime <= 0 && hasStarted == true) {

            //test if collision ended
            if (!_collider.IsTouchingLayers(playerMask)) //asta e inutil. Nu detecteaza coliziuni cat timp sunt shimbate layerele
                reset = true;
        }

        if (reset == true) {

            gameObject.layer = platformMask;
            platformEffector.colliderMask = colliderMask_enabled;

            reset = false;
            hasStarted = false;
        }
    }
}
