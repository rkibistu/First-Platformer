using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootboxOpener : MonoBehaviour {

    private Animator animator;
    private AudioSource audio;
    [SerializeField]
    [Tooltip("Height to spawn the object")]
    private float height = 1f;
    [SerializeField]
    [Tooltip("Things that can be spawned from here")]
    private List<GameObject> prefabs;
    void Start() {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Player") {


            animator.Play("open");
            audio.Play();
        }
    }

    private void DestroyItself() {

        Destroy(gameObject);
    }

    private void SpawnThings() {

        int iterator = Random.Range(0, prefabs.Count);
        var instance = Instantiate(prefabs[iterator]);
        instance.transform.position = transform.position + new Vector3(0f, height, 0f);

        CoinPickUp coinPickup = instance.GetComponent<CoinPickUp>();
        if (coinPickup != null)
            coinPickup.SetValue(10);

    }
}
