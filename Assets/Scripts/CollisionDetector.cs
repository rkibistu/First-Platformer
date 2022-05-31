using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CollisionDetector : MonoBehaviour
{

    public LayerMask groundMask;
    public LayerMask platformMask;
    public LayerMask movingPlatformMask;
    private BoxCollider2D boxColl;
    private Rigidbody2D rb;

    public float skinWidth = .015f;
    public float rayLength = 0.1f;


    void Start()
    {
        boxColl = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    private GameObject isOnSomething(LayerMask layerMask) {

        RaycastHit2D hit = Physics2D.BoxCast(new Vector2(boxColl.bounds.center.x, boxColl.bounds.center.y - boxColl.bounds.extents.y - rayLength/2), new Vector2(boxColl.bounds.size.x, rayLength), 0f, Vector2.down, 0, layerMask);
        Color rayColor;
        if (hit.collider != null) {
            rayColor = Color.green;
        }
        else {
            rayColor = Color.red;
        }
        

        Debug.DrawRay(boxColl.bounds.center + new Vector3(boxColl.bounds.extents.x, -boxColl.bounds.extents.y), Vector2.down * (rayLength), rayColor);
        Debug.DrawRay(boxColl.bounds.center - new Vector3(boxColl.bounds.extents.x, boxColl.bounds.extents.y), Vector2.down * (rayLength), rayColor);
        Debug.DrawRay(boxColl.bounds.center - new Vector3(boxColl.bounds.extents.x, boxColl.bounds.extents.y), Vector2.right * (boxColl.bounds.extents.x * 2), rayColor);
        Debug.DrawRay(boxColl.bounds.center - new Vector3(boxColl.bounds.extents.x, boxColl.bounds.extents.y + rayLength), Vector2.right * (boxColl.bounds.extents.x * 2), rayColor);

        if (hit.collider == null)
            return null;

        return hit.collider.gameObject; // != null;
    }

    public bool isOnSolidSurface() {

        return  isOnPlatform() || isGrounded() || isOnMovingPlatform();
    }


    public GameObject isGrounded() {

        return isOnSomething(groundMask);
    }
    public GameObject isOnPlatform() {

        return isOnSomething(platformMask);
    }
    public GameObject isOnMovingPlatform() {

        return isOnSomething(movingPlatformMask);
    }


    public bool isBottomCornerOnGround(Vector2 velocity) {


        Vector2 rayOrigin = (velocity.x > 0) ? new Vector2(boxColl.bounds.max.x, boxColl.bounds.min.y): new Vector2(boxColl.bounds.min.x, boxColl.bounds.min.y);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, groundMask);

        Color rayColor;
        if(hit.collider != null) {
            rayColor = Color.green;
        }
        else {
            rayColor = Color.red;
        }
        Debug.DrawRay(new Vector3(rayOrigin.x, rayOrigin.y, 0f), Vector2.down * rayLength, rayColor);


        return hit.collider != null;
    }
    public bool isUpperCornerOnGround(Vector2 velocity) {


        Vector2 rayOrigin = (velocity.x > 0) ? new Vector2(boxColl.bounds.max.x, boxColl.bounds.max.y) : new Vector2(boxColl.bounds.min.x, boxColl.bounds.max.y);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, rayLength, groundMask);

        Color rayColor;
        if (hit.collider != null) {
            rayColor = Color.green;
        }
        else {
            rayColor = Color.red;
        }
        Debug.DrawRay(new Vector3(rayOrigin.x, rayOrigin.y, 0f), Vector2.up * rayLength, rayColor);


        return hit.collider != null;
    }
    public bool isLeftCornerOnGround(Vector2 velocity) {


        Vector2 rayOrigin = (velocity.y > 0) ? new Vector2(boxColl.bounds.min.x, boxColl.bounds.max.y) : new Vector2(boxColl.bounds.min.x, boxColl.bounds.min.y);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.left, rayLength, groundMask);

        Color rayColor;
        if (hit.collider != null) {
            rayColor = Color.green;
        }
        else {
            rayColor = Color.red;
        }
        Debug.DrawRay(new Vector3(rayOrigin.x, rayOrigin.y, 0f), Vector2.left * rayLength, rayColor);


        return hit.collider != null;
    }
    public bool isRightCornerOnGround(Vector2 velocity) {


        Vector2 rayOrigin = (velocity.y > 0) ? new Vector2(boxColl.bounds.max.x, boxColl.bounds.max.y) : new Vector2(boxColl.bounds.max.x, boxColl.bounds.min.y);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right, rayLength, groundMask);

        Color rayColor;
        if (hit.collider != null) {
            rayColor = Color.green;
        }
        else {
            rayColor = Color.red;
        }
        Debug.DrawRay(new Vector3(rayOrigin.x, rayOrigin.y, 0f), Vector2.right * rayLength, rayColor);


        return hit.collider != null;
    }


}
