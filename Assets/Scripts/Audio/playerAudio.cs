using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip dash;
    [SerializeField]
    private AudioClip hit;
    [SerializeField]
    private AudioClip swordHit;

    private AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayDashSound() {
        audio.volume = 1f;
        audio.clip = dash;
        audio.Play();
    }
    public void PlayHitSound() {
        audio.volume = 1f;
        audio.clip = hit;
        audio.Play();
    }
    public void PlaySwordSound() {
        float temp = audio.volume;

        audio.volume = 0.15f;
        audio.clip = swordHit;
        audio.Play();

        //audio.volume = temp;
    }
}
