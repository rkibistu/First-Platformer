using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
public class FinishLevel : MonoBehaviour {
    public int m_level;

    private PlayerStatsHandler m_player;
    private void Start() {

        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Player") {

            DataSaver.Health = m_player.GetHealth();
            DataSaver.Coins = m_player.GetCoins();
            LevelLoader.Instance.LoadNextLevel();

            UnlockLevel();
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void UnlockLevel() {

        string m_relativePath = @"ShoppingDaySettings\playerDetails.txt";
        string m_absolutePath = Path.GetFullPath(m_relativePath);

        string lastLevelUnlocked = File.ReadAllLines(m_absolutePath)[0];

        if (m_level >= Int32.Parse(lastLevelUnlocked)) {

            int unlock = m_level + 1;
            string[] lines = File.ReadAllLines(m_absolutePath);
            File.WriteAllText(m_absolutePath, unlock.ToString());
        }
    }
}
