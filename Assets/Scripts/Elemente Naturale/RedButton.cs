using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour {
    [SerializeField]
    private Sprite pressedButton;
    [SerializeField]
    private Door[] doors;

    private SpriteRenderer spriteRender;
    void Start() {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        spriteRender.sprite = pressedButton;

        foreach (Door door in doors) {

            door.OpenDoor();
        }
    }
}
