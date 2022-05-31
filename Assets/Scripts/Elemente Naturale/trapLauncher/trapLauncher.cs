using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapLauncher : MonoBehaviour
{

    [SerializeField]
    private GameObject prefabSpikes;
    [SerializeField]
    private float resetTime = 5f;
    private float resetTimeCounter = 0f;


    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        if (resetTimeCounter > 0)
            resetTimeCounter -= Time.deltaTime;
    }

    private void SpawnSpikes() {

        var instance = Instantiate(prefabSpikes, transform);
        instance.transform.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.gameObject.tag == "Player" && resetTimeCounter <= 0) {

            resetTimeCounter = resetTime;
            animator.Play("shot");
        }
    }
}
