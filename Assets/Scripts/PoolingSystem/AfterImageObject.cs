using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImageObject : MonoBehaviour
{

    private Transform playerTransform;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer player_spriteRenderer;

    [SerializeField]
    private float timeActive = 0.1f;
    private float timeActiveTimer;

    [SerializeField]
    private float alpha = 1f;
    private float alphaCurrent;
    [SerializeField]
    private float alphaMultiplayer = 0.85f;


    private void OnEnable() {

        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player_spriteRenderer = playerTransform.GetComponent<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = player_spriteRenderer.sprite;
        
        timeActiveTimer = timeActive;
        alphaCurrent = alpha;
        spriteRenderer.color = new Color(1f, 1f, 1f, alpha);
        transform.position = playerTransform.position;
        transform.rotation = playerTransform.rotation;
        transform.localScale = playerTransform.localScale;
    }

    private void Update() {

        alphaCurrent *= alphaMultiplayer;
        spriteRenderer.color = new Color(1f, 1f, 1f, alphaCurrent);


        timeActiveTimer -= Time.deltaTime;
        if(timeActiveTimer <= 0) {

            AfterImagePool.Instance.AddToPool(gameObject);
        }
    }

    public void SetPosition(Vector2 position) {

        transform.position = position;
    }

}


