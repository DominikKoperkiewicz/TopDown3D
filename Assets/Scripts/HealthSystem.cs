
using UnityEngine;
using System;

public class HealthSystem {

    public event EventHandler OnHealthChanged;
    
    private int health;
    private int healthMax;

    public HealthSystem(int healthMax) {
        this.healthMax = healthMax;
        health = healthMax;
    }

    public int GetHealth() {
        return health;
    }

    public int GetHealthMax() {
        return healthMax;
    }

    public void Damage(int damegaAmount) {
        health -= damegaAmount;
        if (health < 0) { health = 0; }
        if (OnHealthChanged != null) { OnHealthChanged(this, EventArgs.Empty); }
    }

    public void Heal(int healAmount) {
        health += healAmount;
        if (health > healthMax) { health = healthMax; }
        if (OnHealthChanged != null) { OnHealthChanged(this, EventArgs.Empty); }
    }

    public void SetHealth(int healthValue) {
        health = Mathf.Clamp(healthValue, 0, healthMax);
        if (OnHealthChanged != null) { OnHealthChanged(this, EventArgs.Empty); }
    }

    public void SetHealthMax(int healthMaxValue) {
        healthMax = Mathf.Clamp(healthMaxValue, 0, healthMax);
        if (OnHealthChanged != null) { OnHealthChanged(this, EventArgs.Empty); }
    }

}