using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private PlayerController playerController;
    private CollisionDetector collDet;

    public float speed = 20f;
    public float maxSpeed = 55f;
    public float jumpForce = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        collDet = GetComponent<CollisionDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {

        MovePlayer();
        if (playerController.canJump) {

            Jump();
        }
    }
    private void MovePlayer() {

        float direction = playerController.direction;
        //daca nu mai actionam buton de miscare (stanga/dreapta) sau schimbam directia -> linear drag = 10. Facem asta sa nu avem efect de alunecare
        if (collDet.isGrounded())
            rb.drag = ((Mathf.Abs(rb.velocity.x) > 0.1 && direction == 0) || hasFlipped()) ? 10 : 0;


        rb.AddForce(new Vector2(direction, 0f) * speed * Time.deltaTime, ForceMode2D.Impulse);
        if (Mathf.Abs(rb.velocity.x) > maxSpeed) {

            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }

    }
    private void Jump() {

        rb.drag = 0;
        rb.AddForce(new Vector2(0f, 1f) * jumpForce, ForceMode2D.Impulse);

        playerController.canJump = false;
    }



    private bool hasFlipped() {

        float direction = playerController.direction;
        if (rb.velocity.x < 0 && direction == 1)
            return true;
        if (rb.velocity.x > 0 && direction == -1)
            return true;

        return false;
    }
}
