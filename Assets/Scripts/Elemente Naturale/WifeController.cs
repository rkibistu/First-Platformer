using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifeController : MonoBehaviour
{
    private bool start = false;
    public float timeBeforeInvis = 5f;

    private AudioSource m_audio;
    public bool m_audioEnable = false;

    private void Start() {

        m_audio = GetComponent<AudioSource>();
        if(m_audioEnable)
            StartCoroutine(cryForHelp());
    }

   
    void Update()
    {
        if (start) {

            timeBeforeInvis -= Time.deltaTime;
            if(timeBeforeInvis <= 0) {

                GetComponent<Animator>().Play("Invis");
                start = false;
            }
        }

    }
    IEnumerator cryForHelp() {

        while (true) {

            m_audio.Play();
            yield return new WaitForSeconds(Random.Range(10, 25));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.gameObject.tag == "Player") {

            StopAllCoroutines();
            start = true;
        }
    }

    public void WifeGoVisible() {

        GetComponent<Animator>().Play("Visible");
    }
}
