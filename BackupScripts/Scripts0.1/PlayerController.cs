using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float speed = 10.0f;
    [SerializeField]
    public float maxSpeed = 10.0f;
    public float jumpForce = 100.0f;

    private float direction;
    private bool canJump = false;

    int count = 0;

    private CollisionDetector collDet;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        collDet = GetComponent<CollisionDetector>();
    }

    // Update is called once per frame
    void Update() {

        print(collDet.isGrounded());
    }

    void OnMove(InputValue value) {

        direction = value.Get<Vector2>().x;
    }
    void OnJump() {

        canJump = collDet.isGrounded();
    }

    private void FixedUpdate() {

        MovePlayer();
        if (canJump) {

            Jump();
        }
    }

    private void MovePlayer() {

        //daca nu mai actionam buton de miscare (stanga/dreapta) sau schimbam directia -> linear drag = 10. Facem asta sa nu avem efect de alunecare
        if(collDet.isGrounded())
            rb.drag = ((Mathf.Abs(rb.velocity.x) > 0.1 && direction == 0) || hasFlipped()) ? 10 : 0;


        rb.AddForce(new Vector2(direction, 0f) * speed * Time.deltaTime, ForceMode2D.Impulse);
        if (Mathf.Abs(rb.velocity.x) > maxSpeed) {

            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }

    }
    private void Jump() {

        rb.drag = 0;
        rb.AddForce(new Vector2(0f, 1f) * jumpForce, ForceMode2D.Impulse);

        canJump = false;
    }



    private bool hasFlipped() {

        if (rb.velocity.x < 0 && direction == 1)
            return true;
        if (rb.velocity.x > 0 && direction == -1)
            return true;

        return false;
    }
}
