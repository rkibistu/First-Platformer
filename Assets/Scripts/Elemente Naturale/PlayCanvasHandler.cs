using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayCanvasHandler : MonoBehaviour {

    private GameObject player;
    private PlayerStatsHandler playerStatsHandler;
    
    [Header("Health")]
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Vector2 firstHeartPos;
    public Vector2 heartSize = new Vector2(48f,48f);
    public float spaceBetweenHearts = 1f;
    private GameObject[] hearts;
    private int maxHealth;

    public List<Image> heartsList;

    [Header("Collectables")]
    private GameObject coinsText;

    void Start() {

        player = GameObject.FindWithTag("Player");
        playerStatsHandler = player.GetComponent<PlayerStatsHandler>();

        maxHealth = playerStatsHandler.maxHealth;
        hearts = new GameObject[maxHealth];
        spawnHearts();

        playerStatsHandler.OnHealthChanged += PlayerStatsHandler_OnHealthChanged;
        playerStatsHandler.OnCoinsChanged += PlayerStatsHandler_OnCoinsChanged;

        SetCoinsTextChild();
    }
    private void spawnHearts() {

        for (int i = 0; i < heartsList.Count; i++) {

            if (i < maxHealth)
                heartsList[i].enabled = true;
            else {
                heartsList[i].enabled = false;
            }
        }
    }
    private void SetCoinsTextChild() {

        for (int i = 0; i < gameObject.transform.childCount; i++) {

            Transform child = gameObject.transform.GetChild(i);
            if (child.tag == "CoinsText") {
                coinsText = child.gameObject;
                break;
            }
        }
    }
    private void PlayerStatsHandler_OnHealthChanged(object sender, System.EventArgs e) {

        UpdateNumberOfhearts();
    }
    public void UpdateNumberOfhearts() {

        for(int i = 0; i < maxHealth; i++) {

            if( i >= playerStatsHandler.GetHealth()) {
                heartsList[i].sprite = emptyHeart;
            }
            else
                heartsList[i].sprite = fullHeart;
        }
    }
    private void PlayerStatsHandler_OnCoinsChanged(object sender, System.EventArgs e) {

        UpdateCoinsText();
    }
    public void UpdateCoinsText() {

        coinsText.GetComponent<TextMeshProUGUI>().SetText("Coins: " + playerStatsHandler.GetCoins());

    }
}
