using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    [SerializeField]
    private int value = 1;
    private AudioSource audio;
    private Animator animator;

    private void Start() {

        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        PlayerStatsHandler playerStatsHandler = collision.GetComponent<PlayerStatsHandler>();
        if(playerStatsHandler != null) {

            playerStatsHandler.AddCoins(value);
            animator.Play("Coin_Pickup");
        }
    }

    private void PlaySound() {

        if(audio.enabled)
            audio.Play();
    }
    private void selfDestroy() {

        Destroy(gameObject);
    }

    public void SetValue(int newValue) { value = newValue; }
}
