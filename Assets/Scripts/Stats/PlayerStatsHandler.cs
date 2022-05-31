using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayerStatsHandler : MonoBehaviour {

    public event EventHandler OnHealthChanged;
    public event EventHandler OnCoinsChanged;

    private MovementSM sm;

    [Header("Health")]
    public int maxHealth = 5;
    private int currentHealth;

    [Header("Collectable")]
    private int coins = 0;

    void Start()
    {
        sm = GetComponent<MovementSM>();

        currentHealth = maxHealth;

        coins = DataSaver.Coins;
        if (DataSaver.Health != 0)
            currentHealth = DataSaver.Health;
        Invoke("UpdateCanvasAtStartup", 0.1f);
    }
    private void UpdateCanvasAtStartup() {

        AddCoins(0);
        Heal(0); //sa se reseteze canvasu cu valorile noi, nu cele default
    }

    public int GetHealth() { return currentHealth; }
    public void Damage(int damage) {

        sm.playerAudio.PlayHitSound();

        if (sm.IsInvincible()) { return; }

        currentHealth = Mathf.Max(0, currentHealth - damage);
        if (OnHealthChanged != null)
            OnHealthChanged(this, EventArgs.Empty);

        //is dead
        if (currentHealth == 0) {

            sm.isDead = true;
        }
        else {

            sm.ChangeState(sm.damagedState);
        }
    }
    public void Heal(int heal) {
        
        currentHealth = Mathf.Min(maxHealth, currentHealth + heal);
        if (OnHealthChanged != null)
            OnHealthChanged(this, EventArgs.Empty);
    }

    public void AddCoins(int amount) { 
        
        coins += amount;
        if (OnCoinsChanged != null)
            OnCoinsChanged(this, EventArgs.Empty);
    }
    public void RemoveCoins(int amount) {

        coins -= amount;
        if (OnCoinsChanged != null)
            OnCoinsChanged(this, EventArgs.Empty);
    }
    public int GetCoins() { return coins; }

}
