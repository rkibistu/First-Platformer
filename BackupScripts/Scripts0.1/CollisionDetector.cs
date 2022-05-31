using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CollisionDetector : MonoBehaviour
{

    public LayerMask collisionMask;
    private BoxCollider2D boxColl;
    private Rigidbody2D rb;

    public float skinWidth = .015f;
    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;
    public float rayLength = 1f;

    private float horizontalRaySpacing;
    private float verticalRaySpacing;

    private RaycastOrigins raycastOrigins;
    private CollisionInfo collisions;


    private Vector2 testam;
    void Start()
    {
        boxColl = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        testam = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(testam, Vector2.up * -1 * rayLength, Color.green);
    }
    public bool isGrounded() {

        return VerticalCollisions(-1);
    }


    bool VerticalCollisions(int directionY) {

        UpdateRaycastOrigins();
        for (int i = 0; i < verticalRayCount; i++) {
            Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

            testam = rayOrigin;
            Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength, Color.green);

            if (hit) {

                return true;
            }
        }

        return false;
    }


    void UpdateRaycastOrigins() {
        Bounds bounds = boxColl.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }
    void CalculateRaySpacing() {
        Bounds bounds = boxColl.bounds;
        bounds.Expand(skinWidth * -2);

        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    private struct RaycastOrigins {

        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }
    public struct CollisionInfo {
        public bool above, below;
        public bool left, right;

        public void Reset() {
            above = below = false;
            left = right = false;
        }
    }
}
