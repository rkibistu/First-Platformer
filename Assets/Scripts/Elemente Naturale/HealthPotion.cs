using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour {

    [SerializeField]
    private int health = 1;
    [SerializeField]
    private float speedRotation = 10f;

    private AudioSource audio;
    private SpriteRenderer spriteRenderer;

    private void Start() {

        StartCoroutine("Rotate");

        audio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Player") {

            StartCoroutine("destroyAfterSound");

            collision.gameObject.GetComponent<PlayerStatsHandler>().Heal(health);
            spriteRenderer.enabled = false;
        }
    }

    IEnumerator Rotate() {

        while (true) {

            transform.Rotate(0f, speedRotation, 0f);
            yield return new WaitForSeconds(1 / speedRotation);
        }
    }

    IEnumerator destroyAfterSound() {

        audio.Play();
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
